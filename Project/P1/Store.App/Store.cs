using System;

namespace Store.App
{
    public abstract class Store
    {
        //create all stores common behaviors and properties
        // Field
        public string? name{get;set;}
        public string? storeType{get;set;}
        public string? location{get;set;}
        public string? email{get;set;}
        public string? phone{get;set;}
        // Methods
        public abstract void displayMenu();
        public abstract void GreetingMessage();
        public abstract string ToString();
    }
}