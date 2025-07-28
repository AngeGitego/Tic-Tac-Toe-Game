# 🎮 Tic Tac Toe Game – Unity Project

This is a simple 2D Tic Tac Toe game built using Unity. The project demonstrates key **Object-Oriented Programming (OOP)** principles and implements **three major software design patterns**: Singleton, Observer, and Strategy .

---

##  Object-Oriented Programming Principles

###  Encapsulation
- Core game variables like `currentPlayer` and `gameOver` are private in the `GameManager` class.
- The public method `OnGridClick()` allows other scripts (like buttons) to interact safely with the game logic.

### Abstraction
- Methods like `CheckWinCondition()` and `SwitchPlayer()` hide complex logic, making the main code easier to read and manage.
- The UI doesn't need to know how win-checking works — only that it gets updated.

###  Inheritance *(Optional/Extendable)*
- The game can be extended using a `Player` base class with `HumanPlayer` and `AIPlayer` subclasses to support different types of gameplay.
  
###  Polymorphism *(Optional/Extendable)*
- If player types are added, they can all use the same `MakeMove()` method in different ways, thanks to polymorphism.

---

## 🔁 Design Patterns Used

### 1. Singleton – `GameManager.cs`
Ensures there is only one active `GameManager` instance at any time. Provides a global access point for game state.


public static GameManager Instance { get; private set; }
