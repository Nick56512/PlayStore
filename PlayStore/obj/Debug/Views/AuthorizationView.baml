   M S B A M L   `   `   `  ????D  @PlayStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlayStore.ViewsPlayStore.Views  5      '    !PlayStore.Views.AuthorizationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PlayStore.Views     5        ? DataContext  5	      ??    locator ?? Source# [   ?? Path$ AuthorizationViewModel? ? 	Resources 5       ?? Source?? 5   
   $ /Styles/Styles1.xaml??6   %    6=   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      $??2* ?6   6,   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      $??1.78* ?6   6-   ?? 5      $
??2.3* ?6   6,   ?? 5      $??0 ?6   6)   .+?5!   
   ?? $??1??6   .+?5"      ?? $F??@https://cdn.iconscout.com/icon/free/png-512/play-game-675401.png??6   $	??200??6^   6l   5#      ?? 5%   
   $??1??6   $??1??6"   .+?5&      ?? $??
Логин??6   $
??Left=?6%   $??18(?6@   6Q   ?? 5(       ?? CornerRadius$ 16??6   ???	#FFABADB3$??1q?6?   $??Center=?5)   "    ? UseLayoutRounding . ._?5+      ?? $??0q?6   
?????? $??20(?5-   "   $??5q?5.   "   $??30??5/   "   ??50   "   ?? *Login+52      ?? 54      $??Пароль??6   $
??Left=?6&   $??18(?6A   6R   ?? 55      $ 16??6   ???	#FFABADB3$??1q?6?   $??Center=?56   "    . ._?58      G? -   5        	 G?Name$	 PasswordBox??5=   "   $??0q?58      
?????? $??20(?5:   "   $??5q?5;   "   $??30??5<   "   5=   "   5?      ?? 5@      $??Center=?6   $??5q?64   $??15(?6?   
 d? 	IsChecked
 6M   ?? *SaveProfile+.??6o   CAСохраниться для последующего входа6?   ?? 5A        GreenButton#??[ 6   $??15q?6=   ??6I   ?? *AuthorizationCommand+??5C      ??  ?? ElementName$ PasswordBox??.??6J   
Войти6Q   ?? 5E      $??1q?6.   $??WrapWithOverflow=?69   $??15(?6Y   
???  ????6   ?? *Info+6z   ?? 5F      $??17(?6   &$Нет учетной записи? ?? 5H       ?? Command 6   ?? *GoRegistrationCommand+.?6F   Создайте её5J      5K      5M      5N      5Q      