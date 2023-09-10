# TaQuot
## Introduction
Ce repository a pour but de mettre à disposition une partie des codes sources de l'application TaQuot (contraction de tâche quotidienne).  
Il s'agit d'une application de gestion de fiches de prestations et d'aide à la facturation et monitoring des employés.  
Elle est développée dans le cadre d'un travail de fin d'étude pour la section informatique de gestion de l'institut de promotion sociale d'Arlon.  

## Utilisation
Bien que ce repository n'a pas pour vocation de fournir une application utilisable directement, il est possible de faire tourner le projet en suivant les étapes ci-dessous.  
### Pré requis
- SQL Server
- .net
- node js

### Déroulement  
Par défaut, la local db est utilisée. Ce comportement est modifiable via les fichiers appsettings des applications.  
Une fois la configuration conforme, commencez par compiler les différentes applications backend (AcQua TaQuot et TaQuotAuth) et et à les exécuter.
Dans le fichier "App/TaQuot", installer les différents paquets NPM (par défaut, commande "npm -i").  
Une fois les différents paquets installés, exécuter l'application frontend avec la commande "npm run dev"  
Via votre navigateur web, dirigez vous vers l'url de l'application (http://localhost:5173/   par défaut).  
Créez un compte pour un utilisateur nommé JGO en utilisant un mot de passe comprenant majuscules, minuscules, un caractère spéciale, des chiffres et un minimum de 12 caractères.  
Une fois cet utilisateur créé, utilisé votre gestionnaire de base de donnée pour attribuer le rôle "ADMIN" à l'utilisateur "JGO" dans la table "RolesUtilisateurs".  
Ceci fait, l'utilisateur peut commencer à utiliser l'application.