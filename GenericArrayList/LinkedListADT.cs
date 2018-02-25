/********************************************************
* Jason Thatcher                                        *
* Interface - LinkedListADT.cs                          *
*                                                       *
* Name convention should be ILinkedListADT.  This name  *                                                    
* convention was dictated however. Same for Methods     *
* not being capitalized                                 *
*                                                       *
* February 2018                                         *
*********************************************************/


using System;

namespace LinkedListADTNamespace
{
    public interface LinkedListADT<T>
    {
        //insert() method places one item in the list
        void insert(ref T item);
        //remove() method removes first instance of item in list
        void remove(ref T item);
        //remove() method removes first instance of item in list
        void removeAll(ref T item);
        //print() method prints all items in list
        void print();
        //Max() method returns item with the greatest value from the list
        T Max();
        //Min() method returns item with the greatest value from the list
        T Min();
        //Sort() method sorts the list
        void Sort();

    }
}