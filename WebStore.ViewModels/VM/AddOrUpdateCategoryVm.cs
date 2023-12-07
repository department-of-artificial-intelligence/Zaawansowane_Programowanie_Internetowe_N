namespace WebStore.ViewModels.VM{
    public class AddOrUpdateCategoryVm {
        public int? Id {get; set;}
        public string Name  {get; set;} = default!;
        public string Tag {get; set;} = default!;
    }
}