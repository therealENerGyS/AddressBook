﻿using AddressBook.Services;

var menu = new Menu();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ConsoleContacts.json";

while(true)
{
    Console.Clear();
    menu.MainMenu();
}