namespace PartialClasses
{
    class File2
    {
    }
    public partial class Record
    {
        public void PrintRecord()
        {
            SaveRecord();
            Console.WriteLine("Height:" + h);
            Console.WriteLine("Weight:" + w);
        }

        partial void SaveRecord()
        {
            System.Console.WriteLine("Record Saved.");
        }
    }
}