### Réalité Virtuelle Isitech

#### Objectifs de la Semaine
1. **Rappel du Fonctionnement d’Unity**: Familiarisation avec les bases de l’outil Unity pour ceux qui pourraient avoir besoin d'une remise à niveau.
2. **Travail Collaboratif avec Git**: Introduction et bonnes pratiques pour l’utilisation de Git en conjonction avec Unity.
3. **Bases de la VR dans Unity**: Exploration des concepts et des outils nécessaires pour créer des expériences VR dans Unity.

### Lundi
  
#### 1. Historique XR
- **Concept de Réalité Virtuelle**: Les premières idées remontent à Platon avec l'allégorie de la caverne

- **Dates clés du développement de la VR**:
  - 1935 : Stanley G. Weinbaum décrit des lunettes de réalité virtuelle.
  - 1969 : Ivan Sutherland invente le premier casque VR avec suivi de mouvement.
  - 1995 : Nintendo crée le Virtual Boy.
  - 2010 : Palmer Luckey conçoit le prototype de l’Oculus Rift.
  - 2014 : Oculus Rift est financé via Kickstarter.
  - 2016 : Lancement des HTC Vive, Oculus Rift et PlayStation VR.

#### 2 Git VS Unity
- **Initialisation d’un Projet**: Création du dépôt, configuration de Unity avec Git.
- **Gitignore**: Utilisation d’un modèle spécifique pour Unity.
Git n'étant pas fait pour stocker des fichiers comme des assets de jeux ou des images il faut passer par un autre outil : Git LFS
- **Git LFS**: pour ne pas encombrer l’historique du projet.

#### 3. Outils VR
- **OpenXR**: Standard pour de la compatibilité multi-plateforme.
- **XR Interaction Toolkit**: Boîte à outils pour créer des interactions VR/AR dans Unity.
- **Input System**: Gestion des inputs grâce a un système dans Unity
- **XR Rig**: Représente le joueur dans le monde virtuel, nécessaire pour gérer les positions/rotations de la tête et des contrôleurs.

#### 6. Projet VR

- **Objectifs**: Création d’un projet Unity comprenant trois scènes avec des interactions VR.
  - **Scène A**: Déplacement limité à certaines zones. Le but étant de pouvoir se déplacer/se téléporter à travers un niveau sans tomber sous la map et avec des collisions avec les murs, obstacles

  Pour cela nous avons utilisé des Box Colliders qui permetttent de détecter des collisions et des RigidBody qui donnent aux objets une masse et de la gravité.
  - **Scène B**: Interaction avec des objets et déclenchement d’événements. Nous devions implémenter la fonctionnalité de prise en main d'objets virtuels

  Pour cette scène nous avons utilisé le component XR Grab Interactable qui permet de mettre un point d'ancrage sur un game object nous permettant de le tenir avec les manettes. 
  Il y a aussi un script qui permet de gérer les évènements quand on pose l'objet au bon endroit.


  - **Scène C**: Gestion d’un inventaire avec des interactions physiques.
Le but est de pouvoir prendre des objets, les mettres dans un inventaire et de pouvoir les ressortir. Nous avons implémenté un asset de mains et de différents objets. 

Il y a 1 inventaire par main et 4 emplacements par inventaire. Le tag "collectible" est utilisé pour identifier les objets qui peuvent être ramassés ou non. L'objet est rétrécit lorsqu'il est mis dans l'inventaire et il retrouve sa taille normale quand on le sors de l'inventaire
