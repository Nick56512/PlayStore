   M S B A M L   `   `   `  ????D  @PlayStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlayStore.ViewsPlayStore.Views  5      (    "PlayStore.Views.AdministrationMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PlayStore.Views     5      
??????  ? DataContext  5
      ??    locator ?? Source# [   ?? Path$! AdministrationMenuViewModel? ? 	Resources 5       ?? Source?? 5   
   $ /Styles/Styles1.xaml??6   %    6=   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??0.8* ?6   6.   ?? 5      6!   .+?5   
   ?? $??1??6    ?? Orientation$ 
Horizontal=?6%   .+?5      ?? $	??300??6   $??30??6"   $??15(?6.   $??20,0,0,0q?6V   ??6<   ?? *
GameName+6j   ?? 5      $??50??6   $??30??6    
??? ? ?  SearchButton#??[ 5      ??5   ,   ?? *SearchGameCommand+.??5      ?? $M??Ghttps://cdn2.iconfinder.com/data/icons/font-awesome/1792/search-512.png??6   6k   5      ?? 5       $??40,0,0,0q?6     
ButtonMenu#??[ 6'   $??13(?6N   $
??Bold"?6\   ??6n   ?? *AddNewGameCommand+.??6?   Добавить товар6?   5!      d? 5%   
   -   5         d?Name$ Popup_button??5&      
??????$??	240,0,0,0q?5%   /     AccountButton#??[ 5'      y?5(      ?? *VisibleUserProfile+.??5+      ?? $ 
Horizontal=?6   .+?5,      A? $??60??5-      $??60??5.      ??5/      ?? 50       j? Stretch$ UniformToFill=?6P   	 ?? ImageSource	 6%   ?? *CurrentAdmin.Photo+6j   52      ?? 53      
???????$??16(?6R   $
??Bold"?6`   $??Center=?6r   $??Center=?6?   ??6   ?? *CurrentAdmin.Name+6?   54      55      ?? 56   
   $ 
Horizontal=?6   .+?57      ?? #??[ 6   $
??Bold"?6<   $??13(?6N   ??6\   ?? *GoToMainAdminCommand+.??6?   На главную6?   ?? 59      #??[ 6   $??40,0,0,0q?6e   $
??Bold"?6w   $??13(?6?   ??6<   ?? *ExportToExcelCommand+.??6?   Експорт товаров6?   5:      ? 5;      
 ? 	StaysOpen
 .  ? AllowsTransparency . $
??Fade=?5?       ? HorizontalOffset$	 -28??5@       ? VerticalOffset$ 0??5A      ??5;   )   ?? *	IsChecked+ ?? ElementName$ Popup_button?? ?? Mode$ TwoWay=? ? PlacementTarget 5=      ?? $ Popup_button??.??5B      ??   Popup_style#???  6   y?6C   ?? *VisibleUserProfile+.??5C      ?? $??5 10 5 5q?6   .+?5D      ??   AccountMenuButton#??[ 6   $??10q?6r   ??6K   ?? *ExitProfileCommand+.??6   Выйти с профиля6?   5F      5G      5H      5M      5N      