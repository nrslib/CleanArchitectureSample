# プロジェクトの説明
クリーンアーキテクチャのサンプルです。
C# で記述されています。

詳しい解説はホームページに記載します。
[https://srnlib.com/clean-architecture/](https://srnlib.com/clean-architecture/ "https://srnlib.com/clean-architecture/")

-----

# 構造
クリーンアーキテクチャの形を取っています。

## Presentation
External Interfaces レイヤーの実装です。  
UI 側の実装で Controllers にあたります。  
また Presenter を兼用しています。  
ASP.net MVC(.NET Core) で構成されています。  

## UseCase
Use Cases レイヤーの実装です。  
アプリケーションの利用方法が記載されています。  
UIなどから利用されます。  

## Domain
Entities レイヤーの実装です。  
DDD のコア部分です。  

## InMemoryDataStore
External interface レイヤーの実装です。  
永続化に対する実装であり、Gateways にあたります。  

## MyLibrary
特にどれにも属さない共通クラスライブラリです。  


# Clean architecture
This is a shape of clean architecture.

---
# Structure

## Presentation
External interface layer.  
Implementation for UI.　So-called Controllers.  
It is also used as Presenter.  
Using ASP.net MVC (.NET Core)  

## UseCase
Use Cases layer.  
It describues how to use the application.  
UI etc. use it.  

## Domain
External interface  layer.  
It is the core part of DDD.

## InMemoryDataStore
External interface layer.  
Implementation for data store. So-called gateways.  

## MyLibrary
Common library  
This is a library not belonging to any one.  

---