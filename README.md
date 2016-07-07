# Projet BI
![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/master/Projet%20PlasticBox.PNG)

Ce projet a été réalisé par quatre étudiants du CESI Exia de Toulouse : [Antoine Delia](https://github.com/antoinedelia), [Adrien Jaussaud](https://github.com/RiPNynjamek), [Terence Kouevi](https://github.com/TerenceKOUEVI) et [Léandre Mory](https://github.com/lelandais).

### Sommaire
 - [Introduction](#introduction)
  - [Contexte](#contexte)
  - [Analyse du besoin](#analysebesoin)
    - [Simulateurs de données](#simulateurs)
    - [Centralisation des données](#centralisation)
    - [Analyse des données](#analysedonnées)
    - [Tableau de bord](#tableaudebord)
  - [Mind map](#mindmap)
  - [Représentation du projet](#representation)
  - [Gantt](#gantt)
  - [Choix des technologies](#choixtechnos)
 - [Conception](#conception)
  - [UML](#uml)
  - [Merise](#merise)
    - [Administration](#admin)
    - [Fabrication](#fabrication)
    - [Préparation](#preparation)
    - [Expédition](#expedition)
 - [Mise en place](#miseenplace)
  - [Générateurs](#générateurs)
  - [Infrastructure réseau](#infra)
  - [Serveur NoSql](#nosql)
  - [Tableau de bord](#tableaubord)
 - [Conclusion](#conclusion)

## <a id="introduction">Introduction</a>

### <a id="contexte">Contexte</a>

La société PlasticBoX® aussi appelée PBX, créée des boîtes en plastiques depuis des décennies. Elle a connu un énorme essor dans les années 70 et aujourd'hui son carnet de commandes ne désemplit pas. Depuis 15 ans elle doit faire face à une concurrence beaucoup plus rude sur son domaine, la mondialisation a permis à des sociétés installées dans des pays où les coûts de revient sont beaucoup plus faibles, et ainsi se positionner confortablement sur le marché. Bien que la marque jouisse de sa notoriété, il est teps pour elle de refondre ses méthodes de travail afin de maintenir sa place et surtout sa rentabilité financière dans le cas où elle devrait aligner ses prix.

### <a id="analysebesoin">Analyse du besoin</a>

La firme souhaite améliorer son système de production, son conditionnement et ses expéditions. Mais avant de faire cela de façon effective, elle voudrait essayer et tester une nouvelle architecture. En effet, son système de ventes par le biais de réunions entre particuliers l'oblige à gérer un important volume de données.

#### <a id="simulateurs">Simulateurs de données</a>
Nous allons devoir concevoir des générateurs de données basés sur les fonctions métiers. Il s'agira de petits programmes simulant l'activité de l'entreprise et injectera les données dans des bases de données.

#### <a id="centralisation">Centralisation des données</a>
L'ensemble des données devra être récupéré des différentes bases de données pour être inséré dans une table permettant de faire du NoSQL.

#### <a id="analysedonnées">Analyse des données</a>
Il faudra ensuite analyser les données métier afin de définir des indicateurs pertinents au sein de notre base. Notre objectif est de pouvoir prendre des décisions liées à l'opérationnel et d'améliorer les performances et la réactivité de chaque service.

#### <a id="tableaudebord">Tableau de bord</a>
Enfin, nous devrons mettre en place un tableau de bord de suivi d'activité. Il reprendra les différents indicateurs et permettra de suivre rapidement la santé de l'entreprise sur l'ensemble de ses services.

### <a id="mindmap">Mind map</a>

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/master/Mind%20Map.PNG)

### <a id="representation">Représentation du projet</a>

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/f1f96fa373ee0f572dccafd065d8f0d78319c96c/Sch%C3%A9ma%20Projet%20BI.png)

### <a id="gantt">Gantt</a>
En gestion de projet, un Gantt permet de représenter les tâches à effectuer, ainsi que leur durée. Cela permet d'évaluer l'avancement d'un projet. Pour le notre, nous avons mis en place le Gantt suivant :
![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/master/Gantt.PNG)

### <a id="choixtechnos">Choix des technologies</a>

Ce projet n'a aucune contrainte technique. C'est à nous de définir quelles technologies nous allons utiliser.
Pour la réalisation des générateurs, nous nous sommes mis d'accord pour les développer à l'aide du langage C# et de l'IDE Visual Studio.
MySql sera utilisé pour la réalisation des bases de données relationnelles.
Dans notre DataWarehouse, nous avons une base de données non-relationnel. Nous utilisons CouchDB (document).
Pour nos serveurs, nous utilisons des Windows Server 2008 R2.

## <a id="conception">Conception</a>

### <a id="uml">UML</a>

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/73bd62ad5238b7735f35005bd5eebdd92fc88dbf/UML%20G%C3%A9n%C3%A9rateur.png)

### <a id="merise">Merise</a> 

#### <a id="admin">Administration</a>

![alt tag](https://github.com/antoinedelia/projetBi/blob/master/Merise/Administration.png)

#### <a id="fabrication">Fabrication</a>

![alt tag](https://github.com/antoinedelia/projetBi/blob/master/Merise/Fabrication.PNG)

#### <a id="preparation">Préparation</a>

![alt tag](https://github.com/antoinedelia/projetBi/blob/master/Merise/Preparation.PNG)

#### <a id="expedition">Expédition</a>

![alt tag](https://github.com/antoinedelia/projetBi/blob/master/Merise/Expedition.PNG)

## <a id="miseenplace>Mise en place</a>

### <a id="générateurs">Générateurs</a>

### <a id="infra">Infrastructure réseau</a>

### <a id="nosql">Serveur NoSql</a>

### <a id="tableaubord">Tableau de bord</a>

## <a id="conclusion">Conclusion</a>
