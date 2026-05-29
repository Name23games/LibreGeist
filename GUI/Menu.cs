using LibreGeist.Constants;
using LibreGeist.Core;
using YYTKInterop;
using System;
using System.Collections.Generic;

namespace LibreGeist.GUI
{
    public class Menu
    {
        private readonly Dictionary<string, List<MenuItem>> pages = new();

        private List<MenuItem> currentItems = new();
        private string currentPage = "";
        private int selectedIndex = 0;

        private readonly Func<bool> isActive;
        // Used for mouse position,sounds, and game integrations(TBD)
        private readonly IMenuBridge bridge;

        // Menu Position
        public int X { get; set; }
        public int Y { get; set; }

        // Space between menu items
        public int ItemSpacing { get; set; } = 16;

        // Constructor
        public Menu(
            int x,
            int y,
            Func<bool> isActive,
            IMenuBridge bridge
        )
        {
            X = x;
            Y = y;

            this.isActive = isActive;
            this.bridge = bridge;
        }

        public void SetPage(string page)
        {
            currentPage = page;

            if (!pages.TryGetValue(page, out currentItems!))
            {
                currentItems = new List<MenuItem>();
                pages[page] = currentItems;
            }

            selectedIndex = 0;

            foreach (var item in currentItems)
                item.Selected = false;
        }

        public void AddItem(string page, MenuItem item)
        {
            if (!pages.TryGetValue(page, out var items))
            {
                items = new List<MenuItem>();
                pages[page] = items;
            }

            items.Add(item);
            items.Sort((a, b) => a.Order.CompareTo(b.Order));
        }

        public void Update(float dt)
        {
            if (!isActive())
                return;

            for (int i = 0; i < currentItems.Count; i++)
            {
                var item = currentItems[i];

                if (item.IsInside(bridge.MouseX, bridge.MouseY, X, Y + ItemSpacing * i))
                    selectedIndex = i;

                bool selected = selectedIndex == i;

                if (selected && !item.Selected)
                    bridge.PlaySelectSound();

                item.Selected = selected;
                item.Update(dt);
            }
        }

        public void Draw()
        {
            // Don't draw if inactive
            if (!isActive())
                return;

            // Draw each item
            for (int i = 0; i < currentItems.Count; i++)
            {
                currentItems[i].Draw(
                    X,
                    Y + ItemSpacing * i
                );
            }
        }

        public void MoveUp()
        {
            if (currentItems.Count == 0)
                return;

            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = currentItems.Count - 1;
        }

        public void MoveDown()
        {
            if (currentItems.Count == 0)
                return;

            selectedIndex++;
            if (selectedIndex >= currentItems.Count)
                selectedIndex = 0;
        }

        public void Activate()
        {
            if (currentItems.Count == 0)
                return;

            currentItems[selectedIndex].Action?.Invoke();
        }
    }
}

namespace LibreGeist.GUI
{
    public interface IMenuBridge
    {
        int MouseX { get; }
        int MouseY { get; }

        void PlaySelectSound();
        void PlayConfirmSound();
    }
}