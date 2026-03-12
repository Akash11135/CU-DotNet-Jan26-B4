using System;
using System.Collections.Generic;

public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!studentRecords[studentId].ContainsKey(subject))
            {
                studentRecords[studentId][subject] = marks;
                studentSubjectsOrder[studentId].AddLast(new KeyValuePair<string, int>(subject, marks));

                subjectsRecords[subject][studentId] = marks;
                subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
            }
            else
            {
                int prev = studentRecords[studentId][subject];
                if (marks > prev)
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;
                }
            }

            return 1;
        }

        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId))
                return 0;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);

                var list = subjectsStudentsOrder[subject];
                var node = list.First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        list.Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);

            return 1;
        }

        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject))
                return "";

            int max = int.MinValue;

            foreach (var m in subjectsRecords[subject].Values)
                max = Math.Max(max, m);

            string result = "";

            foreach (var pair in subjectsStudentsOrder[subject])
            {
                if (subjectsRecords[subject].ContainsKey(pair.Key) &&
                    subjectsRecords[subject][pair.Key] == max)
                {
                    result += pair.Key + " " + max + "\n";
                }
            }

            return result.Trim();
        }

        public string Result()
        {
            string res = "";

            foreach (var student in studentRecords)
            {
                int sum = 0;
                int count = 0;

                foreach (var marks in student.Value.Values)
                {
                    sum += marks;
                    count++;
                }

                double avg = (double)sum / count;
                res += student.Key + " " + avg.ToString("F2") + "\n";
            }

            return res.Trim();
        }
    }

    public static void Main()
    {
        CollageManagement cm = new CollageManagement();

        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) break;

            string[] parts = line.Split(' ');

            if (parts[0] == "ADD")
            {
                cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
            }
            else if (parts[0] == "REMOVE")
            {
                cm.RemoveStudent(parts[1]);
            }
            else if (parts[0] == "TOP")
            {
                Console.WriteLine(cm.TopStudent(parts[1]));
            }
            else if (parts[0] == "RESULT")
            {
                Console.WriteLine(cm.Result());
            }
        }
    }
}