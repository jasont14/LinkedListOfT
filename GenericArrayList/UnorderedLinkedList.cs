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
            //sets value parameter of node   
            currentNode.value = item;

            //start is Node from base class and is head of list.
            if (start != null) 
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

            //Cast as IComparables to use CompareTo for generics. Allows reuse code for all types.
            IComparable i1 = (IComparable)item1;  
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

                if (j == -1)     
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

                if (j == 1) 
                {
                    min = temp.next.value;  
                }
                temp = temp.next;
            }

            return min;
        }

        
        //Insertion sort. Overrides method of base class and satisfies interface requirements.
        public override void Sort() 
        {
            Node priorToEval = start;

            //Since first list item is trivally sorted start eval at start.next
            Node eval = priorToEval.next;
            while (eval != null)
            {
                Node priorToCurr = null;
                Node curr = start;

                //compare eval node to each node in list left of eval
                while (TestOrder(eval.value, curr.value) > 0 && curr != null)
                {
                    priorToCurr = curr;
                    curr = curr.next;
                }

                //if it returns to itself don't insert.
                if(eval == curr)
                {
                    priorToEval = priorToEval.next;                        
                }
                else
                {
                    //Once eval is found to be < curr node insert it.
                    //Remove it first
                    priorToEval.next = eval.next;

                    //Now insert it before current
                    eval.next = curr;

                    //Now link prior to eval
                    //Prior may not exist if at start.  Check.
                    if (priorToCurr != null)
                    {
                        priorToCurr.next = eval;
                    }
                    else
                    {
                        start = eval;
                    }
                }
                    
                eval = priorToEval.next;
                    
            }
        }

        //given a numeric position in list returns Node.
        private Node GetItemByPosition(int p)
        {
            Node result = start;  

            int counter = 1;
            while (result.next != null && counter < p) 
            {
                result = result.next; 
                counter++;
            }
            return result;           
        }

        //Returns the number of items in list.
        private int GetListLength()  
        {
            int count = 0;
            Node temp = start;

            while(temp != null) 
            {
                count++;
                temp = temp.next;
            }

            return count;  
        }



    }
}