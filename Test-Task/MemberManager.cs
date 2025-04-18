using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Task
{
    public class MemberManager
    {
        public List<LibraryMember> LibraryMembers{ get; set; } = new List<LibraryMember>();
        private int memberId;
        public MemberManager(List<LibraryMember> members)
        {
            LibraryMembers = members;
            memberId = LibraryMembers.Any() ? LibraryMembers.Count() : 0;
        }

        public void AddMember(LibraryMember member)
        {
            if (member != null)
            {
                member.MemberId = ++memberId;
                LibraryMembers.Add(member);
                Console.WriteLine("Member added Successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }
        public void ViewAllMembers()
        {
            if (LibraryMembers.Any())
            {
                foreach (var member in LibraryMembers)
                {
                    Console.WriteLine(member.toString());
                }
            }
            else
            {
                Console.WriteLine("No members found.");
            }
        }
        public void SearchMemberByName(string name)
            {
                var member = from LibraryMember in LibraryMembers
                             where LibraryMember.Name == name
                             select LibraryMember;
                if (member.Any())
                {
                    Console.WriteLine($"Member Found by {name}:");
                    foreach (var i in member)
                    {
                        Console.WriteLine(i.toString());
                    }
                }
                else
                {
                    Console.WriteLine("Member not found");
                }
            }
        public bool DeleteMember(int memberId)
        {
            var member = LibraryMembers.FirstOrDefault(m => m.MemberId == memberId);
            if (member != null)
            {
                LibraryMembers.Remove(member);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ViewBorrowedMembers()
        {
            var borrowedMembers = LibraryMembers.Where(m => m.memberActivities.Any(a => a.Action == "Borrowed"));
            if (borrowedMembers.Any())
            {
                Console.WriteLine("Members who have borrowed items:");
                foreach (var member in borrowedMembers)
                {
                    Console.WriteLine(member.toString());
                }
            }
            else
            {
                Console.WriteLine("No members have borrowed items.");
            }
        }
    }
}
