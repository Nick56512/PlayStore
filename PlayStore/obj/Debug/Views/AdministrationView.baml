   M S B A M L   `   `   `  ????D  @PlayStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlayStore.ViewsPlayStore.Views  5      (    "PlayStore.Views.AdministrationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PlayStore.Views     5        ? DataContext  5
      ??    locator ?? Source# [   ?? Path$ AdministrationViewModel? ? 	Resources 5       ?? Source?? 5   
   $ /Styles/Styles1.xaml??6   %    6=   .??5      ?  ? RowDefinitions 5   
   ?? 5      6   .+?5   
   ??   ListViewItemStyle#??[ 5      
???????$??1??5      ??5      ?? *Games+ ?? SelectedItem 5      ?? *CurrentGame+??5!      ?? 5"      .R?5#      ?  ? ColumnDefinitions 5%      ?? 5&      61   ?? 5'      61   ?? 5(      61   ?? 5)      61   .+?5,      ?? $??0??6%   .+?5.      ?? $	??160??6=   $	??170??6I   ??6$   ?? *Cover+6X   50      ?? 52      $??1??6%   $??20,0,0,0q?65   .+?54      ?? $??5q?6(   $??16(?63   $??Right=?6A   Название:6h   ?? 55      $??5q?6(   $??16(?63   $??Right=?6A   	Цена:6d   ?? 56      $??5q?6(   $??16(?63   $??Right=?6A   	Жанр:6d   ?? 57      $??5q?6(   $??16(?63   $??Right=?6A   Создатель:6i   ?? 58      $??5q?6(   $??16(?63   $??Right=?6A   Дата релиза:6k   5:      ?? 5<      $??2??6%   $??10,0,0,0q?65   .+?5>      ?? $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *Name+6?   ?? 5?      $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *Price+6?   ?? 5A      $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *Genre+6?   ?? 5B      $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *	Developer+6?   ?? 5D      $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *ReleaseDate+6?   5F      ?? 5I       ?? Orientation$ Vertical=?6%   $??3??6<   $??50,0,0,0q?6L   .+?5J      ??   OrangeButton#??[ 6%   $??0,50,0,0q?6N   ??5K   %   ?? 	 ?? RelativeSource	 ?? 
 ?? Mode$
 FindAncestor=? ?? AncestorType" >?$# DataContext.RemoveGameCommand?.??6?   Удалить6?   ?? 5M        
BlueButton#??[ 6%   $??0,20,0,0q?6L   ??5N   %   ?? 	 ?? $
 FindAncestor=?" >?$# DataContext.UpdateGameCommand?.??6?   Редактировать6?   5P      5R      5S      5U      5W      5X      