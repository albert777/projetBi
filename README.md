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
    - [Indicateurs](#indicateurs)
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

Avant de développer nos générateurs, nous avons fait une phase de conception afin de créer un UML qui représentera l'architecture de notre application.

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/73bd62ad5238b7735f35005bd5eebdd92fc88dbf/UML%20G%C3%A9n%C3%A9rateur.png)

### <a id="merise">Merise</a> 

Pour chaque base de données, nous avons conçu un Merise afin de prévoir toute éventualité. Nous nous sommes servi de JMerise afin de le réaliser. Dans un premier temps, nous avons créer un MCD en incluant les tables et leurs colonnes. Ensuite nous avons généré le MCD corrsepondant.

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

On doit mettre en place une infrastructure réseau pour la société Plasticbox. Dans cette société, nous pouvons trouver plusieurs services : administration, préparation, fabrication et expédition. Ces derniers contiennent chacun un serveur. Afin d'améliorer l'infrastructure de l'entreprise, nous avons mis en place une redondance afin d'assurer le bon fonctionnement du réseau de la société. Par ailleurs, l'infrastructure de l'entreprise respecte un découpage où chaque service correspond à un VLAN précis.

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/master/infra.png)

Pour pouvoir réaliser le découpage des adresses IP de l'entreprise, il y a plusieurs VLAN. Chacun d'eux doit avoir son propre réseau. Afin d'y parvenir, nous sommes partis sur une adresse IP de classe B (172.16.0.0) privée, en utilisant la technique du VLSM qui est utilisée dans le but de mieux gérer les adresses IP tout comme le CIDR. La différence est que le CIDR est majoritairement utilisé au niveau Internet, alors que le VLSM est plus utilisé au niveau local.

_Les VLAN:_  

Service| VLAN | Adresse réseau | Première adresse | Dernière adresse | Broadcast | CIDR | Masque de sous-réseau
--- | --- | --- | --- | --- | --- | --- | --- 
Préparation | 10 | 172.16.0.0 | 172.16.0.1 | 172.16.0.30 | 172.16.0.31 | /27 | 255.255.255.224
Fabrication | 20 | 172.16.0.32 | 172.16.0.33 | 172.16.0.62 | 172.16.0.63 | /27 | 255.255.255.224
Administration | 30 | 172.16.0.64 | 172.16.0.65 | 172.16.0.94 | 172.16.0.95 | /27 | 255.255.255.224
Expédition | 40 | 172.16.0.96 | 172.16.0.97 | 172.16.0.126 | 172.16.0.127 | /27 | 255.255.255.224

![alt tag](https://raw.githubusercontent.com/antoinedelia/projetBi/master/infra2.png)

### <a id="nosql">Serveur NoSql</a>

### <a id="tableaubord">Tableau de bord</a>

Le tableau de bord permet de reprendre les différents indicateurs et permet de suivre rapidement la santé de l'entreprise sur l'ensemble de ses services.

#### <a id="indicateurs">Indicateurs</a>

Pour ce projet, nous avons utilisé les indicateurs suivants :

 - Administration
  - Produits les plus vendus
  - Produits les moins vendus
  - Produits populaires en fonction de la couleur
  - Prix moyenne d'une commande
  - Taux de commandes annulées
  - Taux de satisfaction par commande
  - Taux de satisfaction par pays
  - Écart entre date prévisionnelle et effective d'une commande
  - Nombre de produits par commande
  - Nombre de commandes par client
  - Âge par client
  - Pays avec le plus de commandes
  - Chiffre d'affaire par pays
 - Préparation
  - Temps moyen de la préparation d'une commande
 - Expédition
  - Temps moyen entre la commande et son expédition
 - Fabrication
  - Nombre de produits fabriqués
  - Stock d'un produit
  - Temps moyen d'assemblage par produit
  - Temps moyen d'assemblage par pièce
  - Rendement d'une machine
  - Nombre de pannes pour une machine
  - Temps moyen d'une panne
  - Machine les plus utilisées

## <a id="conclusion">Conclusion</a>
