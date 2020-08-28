using Microsoft.AspNetCore.Mvc.Razor;
public abstract class CustomRazorPage<TModel> : RazorPage<TModel>
{
 public string StaticURL=>"/test/";

//  public string Prop1 {
//       get{
//      return "";
//          } 
//  }

}
