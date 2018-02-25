/********************************************************
* Jason Thatcher                                        *
* Class - UnorderedLinkedList.cs                        *
*                                                       *
* Name convention should capitalize Methods Naming was  *
* dictated for some methods however.                    *
*                                                       *
* February 2018                                         *
*********************************************************/

using System;
using LinkedListNamespace;
using LinkedListADTNamespace;

namespace UnorderedLinkedListNamespace
{
    public class UnorderedLinkedList<T> : LinkedList<T>, LinkedListADT<T>
    {
        //:base() references constructor of LinkedList<T> that requires no parameters.
        public UnorderedLinkedList() : base()
        {
        }

        //Adds Node to end of list. Overrides method of base class and satisfies interface requirements.
        public override void insert(ref T item)
        {
            Node currentNode = new Node();            
            currentNode.value = item; //sets value parameter of node            

            if (start != null) //start is Node from base class and is head of list.
            {
                end.next = currentNode; //Adds the node at the end.
                end = currentNode; //Sets end to reference last node.
            }
            else
            {
                start = currentNode;
                end = start;
            }
        }

        //Adds Removes All occurrences of item in list. Overrides method of base class and satisfies interface requirements.
        public override void removeAll(ref T item)
        {
            if (start != null) //quick check
            {
                Node temp = start;
                while (temp.next != null)  //loop until end.
                {
                    if (temp.next.value.Equals(item)) //compare values of next and item.  if next == item remove pointer to next, has the effect of removing item from list.
                    {                            
                        if (temp.next.next != null)  //Note unlike remove() in base this does not break once change occurs. This loops til end removes all.
                        {
                            Node t = temp.next.next;
                            temp.next = t;
                        }
                        else                         
                        {
                            temp.next = null;
                            end = temp;             //Update last node reference;
                            break;
                        }
                    }
                    temp = temp.next;
                }             
            }
        }

        //Compares two items.  return -1 if preceeds, 0 if equal, 1 if follows.
        private int TestOrder(T item1, T item2)
        {
            int result = 99;

            IComparable i1 = (IComparable)item1;  //Cast as IComparables to use CompareTo for generics. Allows reuse code for all types.
            IComparable i2 = (IComparable)item2;

            if (i1.CompareTo(i2) < 0)
            {
                result = -1;                //Preceeds
            }

            else if (i1.CompareTo(i2) == 0)
            {
                result = 0;                 //Equal
            }

            else if (i1.CompareTo(i2) > 0)
            {
                result = 1;                 //follows
            }

            return result;
        }

        //Return the max value. Overrides method of base class and satisfies interface requirements.
        public override T Max()
        {
            T max = start.value;
            Node temp = start;

            while (temp.next != null)
            {
                int j = TestOrder(max, temp.next.value);

                if (j == -1)     //if -1 max preceeds or is "less than" next.value. 
                {
                    max = temp.next.value;  //Update new max.
                }
                temp = temp.next;
            }

            return max;
        }

        //Return the min value. Overrides method of base class and satisfies interface requirements.
        public override T Min()
        {
            T min = start.value;
            Node temp = start;

            while (temp.next != null)
            {
                int j = TestOrder(min, temp.next.value);

                if (j == 1) //if 1, min follows or is "greater than" next.value. 
                {
                    min = temp.next.value;  //Update new min.
                }
                temp = temp.next;
            }

            return min;
        }

        //Sorts list
        public override void Sort() //This sort uses an insertion sort. Overrides method of base class and satisfies interface requirements.
        {
            int length = GetListLength()+1;
            
            for (int j = 2; j<length; j++)  //Start at 2 since 1 is trivally sorted.
            {
                Node evalNode = GetItemByPosition(j); //Sets the Node to evaluate

                for (int i = j-1; i > 0; i--) //Sets comparison Node starting at i-1 until hits 0 = left most end of list.
                {
                    Node priorNode = GetItemByPosition(i); 
                    int result = TestOrder(evalNode.value, priorNode.value); //Comparison. Returns -1 less than, 0 equal, 1 greater than
                    
                    if (result == -1) //if less swap...
                    {
                        T priorValue = priorNode.value;
                        T evalValue = evalNode.value;

                        Node temp = priorNode;
                        priorNode = evalNode;   //swap nodes.  Now priorNode.next points evalNode.next
                        priorNode.value = priorValue;  //keep value

                        evalNode = temp; //swap nodes. Now evalNode.next points to updated priorNode.  
                        evalNode.value = evalValue; //keep value.  Swap complete.

                        if (i == 1)  //if i==1 then at start of list.
                        {
                            start =  evalNode;
                        }
                    }
                }
            }
        }

        //given a numeric position in list returns Node.
        private Node GetItemByPosition(int p)
        {
            Node result = start;  //start at left most

            int counter = 1;
            while (result.next != null && counter < p) //count until at node prior to target.
            {
                result = result.next; //this ticks to target node @ counter < p.
                counter++;
            }
            return result;           //returns target node
        }

        //Returns the number of items in list.
        private int GetListLength()  
        {
            int count = 0;
            Node temp = start;

            while(temp != null)  //simple counter to count number of items in list at temp == null is end of list.
            {
                count++;
                temp = temp.next;
            }

            return count;  //return number
        }



    }
}