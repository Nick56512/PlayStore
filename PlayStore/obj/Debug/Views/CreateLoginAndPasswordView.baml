   M S B A M L   `   `   `  ????D  @PlayStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlayStore.ViewsPlayStore.Views  5      0    *PlayStore.Views.CreateLoginAndPasswordView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PlayStore.Views     5        ? DataContext  5	      ??    locator ?? Source# [   ?? Path$% CreateLoginAndPasswordViewModel? ? 	Resources 5       ?? Source?? 5   
   $ /Styles/Styles1.xaml??6   %    6=   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      $??2* ?6   6,   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      6   ?? 5      $
??2.3* ?6   6,   ?? 5      6   .+?5   
   ?? $??1??6   $??1??6"   .+?5      ?? $I??CПридумайте логин(не менее 6 символов)??6   $
??Left=?6E   $??18(?6`   6q   ?? 5        ?? CornerRadius$ 16??6   ???	#FFABADB3$??1q?6?   $??Center=?5!   "    ? UseLayoutRounding . ._?5#      ?? $??0q?6   
?????? $??20(?5%   "   $??5q?5&   "   $??30??5'   "   ??5(   "   ?? $ NewUser.Login?5*      ?? 5,      $'??!Придумайте пароль??6   $
??Left=?61   $??18(?6L   6]   ?? 5-      $ 16??6   ???	#FFABADB3$??1q?6?   $??Center=?5.   "    . ._?50      G? -   5        	 G?Name$	 PasswordBox??55   "   $??0q?50      
?????? $??20(?52   "   $??5q?53   "   $??30??54   "   55   "   57      ?? 58        OrangeButton#??[ 6   $??15q?6>   ??6J   ?? *RegistrationCommand+??5:      ?? 
 ?? ElementName$
 PasswordBox??.??6J   &$Зарегистрироваться6^   ?? 5<      $??28q?6.   $??WrapWithOverflow=?6:   $??15(?6Z   
???  ????6   ?? *Info+6{   5A      ?? 5B   
   .+?5C      ?? $??20q?6   $??0??6!   $??0??6.   
???????
?????????6Q   ?? *GoBackCommand+.??5D      ?? $1??+https://img.icons8.com/ios/452/back--v1.png??6   $??70??6M   $??40??6X   6f   5E      5F      5G      5H      