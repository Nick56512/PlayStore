   M S B A M L   `   `   `  ????D  @PlayStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlayStore.ViewsPlayStore.Views  5          PlayStore.Views.CartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PlayStore.Views     5        ? DataContext  5	      ??    locator ?? Source# [   ?? Path$ CartViewModel? ? 	Resources 5       ?? Source?? 5   
   $ /Styles/Styles1.xaml??6   %    6=   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??1.6* ?6   6.   ?? 5      6!   .+?5   
   ??   ListViewItemStyle#??[ 5      
???????$??Disabled=?5      ??5      ?? *	CartGames+ ?? SelectedItem 5      ?? *CurrentGame+??5      ?? 5      .R?5      ?  5      ?? 5       61   ?? 5!      61   ?? 5"      61   ?? 5#      61   .+?5&      ?? $??0??6%   .+?5(      ?? $	??160??6=   $	??170??6I   ??6$   ?? *Cover+6X   5*      ?? 5,      $??1??6%   $??20,0,0,0q?65   .+?5.      ?? $??5q?6(   $??16(?63   $??Right=?6A   Название:6h   ?? 5/      $??5q?6(   $??16(?63   $??Right=?6A   	Цена:6d   51      ?? 53      $??2??6%   $??10,0,0,0q?65   .+?54      ?? $??5q?6(   $??16(?63   $
??Left=?6A   ??6\   ?? *Name+6t   ?? 55      $??5q?6(   $??16(?63   $
??Left=?6A   $
??Bold"?6\   ??6n   ?? *Price+6?   56      ?? 58       ?? Orientation$ Vertical=?6%   $??3??6<   $??40,0,0,0q?6L   .+?59      ??   OrangeButton#??[ 6%   $??0,50,0,0q?6N     ButtonStyle#??[ 6`   ??5:   %   ??  ?? RelativeSource ?? 	 ?? Mode$	 FindAncestor=?
 ?? AncestorType"
 >?$# DataContext.DeleteGameCommand?.??6?   Удалить6?   5;      5?      5@      5E      ?? 5H   
   $??1??6   $ Vertical=?6%   
???   ?.+?5I      ?? $??20(?6   $
??Left=?6&   
???????$
??Bold"?6T   ?? 5J      $ 
Horizontal=?6   .+?5L      ?? $??
20,140,0,0q?6    Всего:6<   ?? 5M      $??	5,140,0,0q?6    $??DemiBold"?6J   ??63   ?? *Price+6b   ?? 5N      $B??<https://money24.vn.ua/wp-content/uploads/2020/09/USD-min.png??6   $??40??6b   $??30??6n   $??	5,130,0,0q?6y   6?   5P      5Q      ?? 5S      $??20(?6   ?? 5T      $ 
Horizontal=?6   .+?5V      ?? $
??Bold"?6   
???????$??20q?6C   !Остаток на счету:6b   ?? 5W      $??DemiBold"?67   
???????$??0,20,0,0q?6`   ??6   ?? *	Balance+6t   ?? 5X      $B??<https://money24.vn.ua/wp-content/uploads/2020/09/USD-min.png??6   $??40??6`   $??30??6l   6y   5Z      5[      ?? 5]        
BlueButton#??[ 6   $??30??6<   ??6H   ?? *BuyGamesCommand+.??6l   Оплатить6v   5_      5a      5b      