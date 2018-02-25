/********************************************************
* Jason Thatcher                                        *
* Base Class - LinkedList.cs                            *
*                                                       *
* Note: 'Abstract' keyword before class prevents this   *
* base class from being instantiated directly.          *
*                                                       *
* Name convention for Methods should be capitalized.    *
* These methods and names were dictated however.        *
*                                                       *
* February 2018                                         *
*********************************************************/

using System;
using LinkedListADTNamespace;

namespace LinkedListNamespace
{
    public abstract class LinkedList<T>
    {
        //'Node' class. Note: protected classes cannot be a top level class.  Derived classes will have access to this inner class.
        protected class Node
        { 
            public T value;
            public Node next;
        }
        
        protected Node start; //keeps track of head of list.
        protected Node end = new Node(); //Keeps track of end or last node.  Allows insert at end without having to loop thru list finding Node.Next == null.

        //Constructor
        public LinkedList()
        {
            start = null;
            end = start;
        }
        
        //abstract methods require derived classes implement details.  Note: { } are missing.
        //insert method to add to list
        public abstract void insert(ref T item);
        //remove all method to remove all occurences of item
        public abstract void removeAll(ref T item);
        //return min value of T from list
        public abstract T Min();
        //return max value of T from list
        public abstract T Max();
        //Sort list
        public abstract void Sort();


        //Methos removes an item T from list.
        public void remove(ref T item)
        {
            if (start != null) //quick check
            {
                if (start.value.Equals(item)) //values of items match?
                {
                    Node t = start.next;
                    start = t;                    
                }
                else  //if found this moves pointer to next.next
                {
                    Node temp = start;
                    while (temp.next != null)  //make sure there is a next
                    {
                        Node eval = temp.next;
                        if (eval.value.Equals(item))
                        {
                            if (temp.next.next != null)  //makes sure next item is not null. Breaks once set
                            {
                                temp.next = temp.next.next;
                                break;                     
                            }
                            else
                            {
                                temp.next = null;  //if so make .next null because it is at the end of the list. Breaks once set
                                end = temp; //set as end of list.
                                break;
                            }
                        }
                        temp = temp.next;
                    }
                }                
            }            
        }        

        
        //prints list to screen.
        public void print()
        {
            Node current = start;
            while (current != null)
            {
                Console.Write((T)(current.value) + "   ");
                current = current.next;
            }
            Console.WriteLine();
        }
        
    }
}