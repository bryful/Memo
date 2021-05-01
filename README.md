# Memo.exe

長らく愛用していたテキストエディタTeraPadが最近のWindowsでまともに動かなくなったので困って作ったものです。  
高機能なエディタはVS Codeがあるのですが、簡単に使えるものが欲しくて作りました。  
  
エディタ部分はC#のTextBoxなので性能は低いですが、さっと起動してメモを書く機能が欲しかったので、
予め30個のテキストエリアをタブで切り替えて使うってUIにしてあります。基本的にファイルの保存読み込みは意識しないでも使える様になっています。


仕事でAfter Effectsを使ってる時に使う事が多かったので、同時併用が楽なようにしてあります。

# 使い方

起動させて適当なタブに書き込みます。終了しても保存されます。

File/Exportで保存できます。開いてるタブに読み込まれます。保存時の文字コードはFileメニューで設定できます。
File/Importで開いてるタブにファイルを読めます。


Edit/Clearで現在開いてるタブを消去します。  
Edit/EditCaptionでタブの見出しを編集できます。  
Edit/SelectionToCaptionで現在選択中のテキストを見出しにできます。  
FontSettingsでフォントを設定できます。  
Copy/Pasteはコピー・ペーストです。  
Memesメニューはテキストが入力されたタブのリストが表示されます。  


# Dependency
Visual studio 2019 C#  


# License

This software is released under the MIT License, see LICENSE

# Authors

bry-ful(Hiroshi Furuhashi)   
twitter:bryful  
bryful@gmail.com  

