using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public  class InventoryManagement
    {
        public static ObservableCollection<Component> DatabaseInventory{ get; set; } = new ObservableCollection<Component>();

        public static ObservableCollection<Component> GetInventory()
        {
            if (DatabaseInventory.Count == 0)
            {
                // Add CPU components
                DatabaseInventory.Add(new Component("7463719", "Intel i7-10700K", "Intel", "Core i7-10700K", 350.99, Category.CPU, 0));
                DatabaseInventory.Add(new Component("343719", "AMD Ryzen 9 5900X", "AMD", "Ryzen 9 5900X", 549.99, Category.CPU, 5));
                DatabaseInventory.Add(new Component("123456", "Intel Core i9", "Intel", "Core i9-9900K", 399.99, Category.GPU, 3));
                DatabaseInventory.Add(new Component("654321", "AMD Ryzen 5 5600X", "AMD", "Ryzen 5 5600X", 299.99, Category.RAM, 5));
                DatabaseInventory.Add(new Component("987654", "Intel Core i5", "Intel", "Core i5-11600K", 269.99, Category.SSD, 2));
                DatabaseInventory.Add(new Component("123789", "AMD Ryzen 7 ", "AMD", "Ryzen 7 5800X", 399.99, Category.Mother_Board, 5));

                // Add GPU components 
                DatabaseInventory.Add(new Component("12745", "NVIDIA GeForce RTX 3060 Ti", "NVIDIA", "GeForce RTX 3060 Ti", 399.99, Category.PSU, 5));
                DatabaseInventory.Add(new Component("31344", "AMD Radeon RX 6700 XT", "AMD", "Radeon RX 6700 XT", 479.99, Category.GPU, 2));
                DatabaseInventory.Add(new Component("54321", "NVIDIA GeForce", "NVIDIA", "GeForce RTX 3080", 699.99, Category.GPU, 20));
                DatabaseInventory.Add(new Component("98765", "AMD Radeon ", "AMD", "Radeon RX 6800 XT", 649.99, Category.GPU, 10));
                DatabaseInventory.Add(new Component("13579", "NVIDIA GeForce RTX 3070", "NVIDIA", "GeForce RTX 3070", 499.99, Category.GPU, 2));
                DatabaseInventory.Add(new Component("24680", "AMD Radeon RX 6700", "AMD", "Radeon RX 6700", 479.99, Category.GPU, 30));

                // Add RAM components
                DatabaseInventory.Add(new Component("12345", "Corsair Vengeance", "Corsair", "Vengeance LPX 16GB DDR4", 89.99, Category.RAM, 1));
                DatabaseInventory.Add(new Component("56789", "G.SKILL Trident Z ", "G.SKILL", "Trident Z RGB 32GB DDR4", 169.99, Category.RAM, 6));
                DatabaseInventory.Add(new Component("13579", "Crucial Ballistix", "Crucial", "Ballistix 16GB DDR4", 79.99, Category.RAM, 6));
                DatabaseInventory.Add(new Component("24680", "Kingston", "Kingston", "HyperX Fury 8GB DDR4", 49.99, Category.RAM, 5));
                DatabaseInventory.Add(new Component("98765", "ADATA XPG ", "ADATA", "XPG Z1 16GB DDR4", 99.99, Category.RAM, 1));
                DatabaseInventory.Add(new Component("54321", "TeamGroup T-Force Delta RGB 32GB DDR4", "TeamGroup", "T-Force Delta RGB 32GB DDR4", 189.99, Category.RAM, 10));

                // Add SSD Inventorys
                DatabaseInventory.Add(new Component("11111", "Samsung 970 EVO", "Samsung", "970 EVO Plus 1TB", 179.99, Category.SSD, 6));
                DatabaseInventory.Add(new Component("22222", "Western Digital", "Western Digital", "WD Blue SN550 500GB", 54.99, Category.SSD, 10));
                DatabaseInventory.Add(new Component("33333", "Crucial ", "Crucial", "MX500 1TB", 104.99, Category.SSD, 5));
                DatabaseInventory.Add(new Component("44444", "Seagate FireCuda", "Seagate", "FireCuda 520 1TB", 199.99, Category.PSU, 3));
                DatabaseInventory.Add(new Component("55555", "Intel 660p ", "Intel", "660p Series 1TB", 119.99, Category.SSD, 1));
                DatabaseInventory.Add(new Component("66666", "ADATA", "ADATA", "XPG SX8200 Pro 1TB", 139.99, Category.PSU, 3));

                // Add Motherboard components
                DatabaseInventory.Add(new Component("77777", "ASUS ROG Strix", "ASUS", "ROG Strix Z590-E", 299.99, Category.Mother_Board, 5));
                DatabaseInventory.Add(new Component("88888", "MSI MPG B550", "MSI", "MPG B550 GAMING PLUS", 139.99, Category.Mother_Board, 2));
                DatabaseInventory.Add(new Component("99999", "GIGABYTE B550 AORUS ELITE", "GIGABYTE", "B550 AORUS ELITE", 159.99, Category.Mother_Board, 8));
            }
            return DatabaseInventory;
        }
        public static void AddInventory(Component component)
        {
            DatabaseInventory.Add(component);
        }
        public static void DeleteInventory(Component component)
        {
            DatabaseInventory.Remove(component);
        }
        public static void EditInventory(Component SelectedItem, string? componentName, string? componentBrand, string? componentModel, double componentPrice, Category? componentCategory, int? componentQuantity)
        {
            SelectedItem.ComponentName = componentName;
            SelectedItem.ComponentBrand = componentBrand;
            SelectedItem.ComponentModel = componentModel;
            SelectedItem.ComponentPrice = componentPrice;
            SelectedItem.ComponentCategory = componentCategory;
            SelectedItem.ComponentQuantity = componentQuantity;


        }
    }
}
