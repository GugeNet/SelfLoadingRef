namespace RefLoader
{
    public class Role
    {
        public string Name { get; set; }
        
        public Person Person { get; set; }
        
        public VRef<Company> Company { get; set; }
    }
}