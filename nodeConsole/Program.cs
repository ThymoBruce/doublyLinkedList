using nodeConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        /// <summary>
        /// rankschik x asc
        /// </summary>
        /// <algo>
        /// ask for n many numbers that need to be rankschikked asc
        /// make a new int[] x with n amount of numbers
        /// make an int min, max where min cannot be 0 because than the program wil break;
        /// make every item in x a new random int between min and max
        /// create a node[] with the length of x
        /// for every node in node[] make a new node but without any values
        /// loop through x till k has the same value of x.length
        /// loop through node and look if node[i].value == 0
        /// if true set the value of node[i] = x[k] and give it the name = node_i.tostring
        /// break when that's done
        /// if the value of node[i] is not 0 and i is greater or equal to one set the next and previous
        /// check if node[i].value is lesser than node[0].value
        /// if true set the value of node[i] to node[0] and value of node[0] to node[i]
        /// else look if the value of node[i] is lesser than node[i-1] if so swap the 2 values explained above
        /// </algo>
        static void Main(string[] args)
        {
            Console.WriteLine("please give me how many numbers I need to rankschik");
            int n = Convert.ToInt32(Console.ReadLine());
            int min = 1;
            int max = 20;
            int[] x = new int[n];
            Random rand = new Random();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rand.Next(min, max);
            }
            nodes[] node = new nodes[x.Length];
            for (int i = 0; i < node.Length; i++)
            {
                node[i] = new nodes();
            }
            nodes tempnode = new nodes();
            //why does looping twice over the length of x work to sort it complete
            //when the length of x is greater than 10
            for (int k = 0; k <= x.Length*2; k++)
            {
                for (int i = 0; i < node.Length; i++)
                {
                   if(node[i].value == 0)
                    {
                        node[i].value = x[k];
                        node[i].nodename = "node_" + i.ToString();
                        break;
                    }
                    else
                    {
                        if(i >= 1)
                        {
                            //if i is greater or equal than 1 set the next and previous
                            node[i - 1].next = node[i];
                            node[i].previous = node[i - 1];
                        }
                       //check if the value of node[i] is lesser than node[0]
                        if(node[i].value < node[0].value)
                        {
                            //swap the 2 values
                            tempnode.value = node[0].value;
                            node[0].value = node[i].value;
                            node[i].value = tempnode.value;
                        }
                        else
                        {
                            if(i >= 2 && node[i].value < node[i - 1].value)
                            {
                                tempnode.value = node[i - 1].value;
                                node[i - 1].value = node[i].value;
                                node[i].value = tempnode.value;
                            }
                            else
                            {
                                if (node[node.Length-1].value > 0 && node[i].value > node[node.Length-1].value)
                                {
                                    tempnode.value = node[node.Length - 1].value;
                                    node[node.Length - 1].value = node[i].value;
                                    node[i].value = tempnode.value;
                                }
                            }
                        }
                    }
                }
            }
            node[0].nodename = "head";
            node[node.Length - 1].nodename = "tail";
            foreach (var item in node)
            {
                Console.WriteLine("The value of: " + item.nodename + " is: " + item.value.ToString());
            }
            Console.ReadLine();
        }
    }
}
