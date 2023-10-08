# WallBreaker
I developed the project to improve my architectural skills and gain practical experience.

-> The project is coded in accordance with COP (Component Oriented Programming).

-> Zenject (Extenject in Asset Store) was used to break dependencies in the project (such as Movement Component-DataManager).

-> The components in the project are fed from BaseClasses and do not need other components to work

=> Except for the AnimationComponent. Animation Component can't work without TriggerComponent and MovementComponent. there is a requirement for other components in animationComponent to avoid any error.

-> The character data in the game is saved and loaded with NewtonSoftJson.

-> Namespaces and #regions are used to keep the code clean and readable.

-> The raycast system is used so that the character does not detect multiple walls and does not have a mechanical error.

-> Scriptable Objects were used to facilitate easy initialization of wall data, prevent clutter, enable the effortless addition of new walls, and ensure code optimization. (The FlyWeight pattern could have also been employed for optimization.)

