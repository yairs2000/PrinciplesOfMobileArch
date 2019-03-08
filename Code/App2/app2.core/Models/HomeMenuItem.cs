using System;
using System.Collections.Generic;
using System.Text;

namespace app2.core.Models
{
  public enum MenuItemType
  {
    Browse,
    About
  }
  public class HomeMenuItem
  {
    public MenuItemType Id { get; set; }

    public string Title { get; set; }
  }
}
