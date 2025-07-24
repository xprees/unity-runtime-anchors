# Unity Runtime Anchors

[![NPM Version](https://img.shields.io/npm/v/cz.xprees.runtime-anchors)](https://www.npmjs.com/package/cz.xprees.runtime-anchors)

This package provides a solution for managing runtime anchors in Unity.

## What is Runtime Anchor?

Runtime anchors is the primitive based on ScriptableObject, which helps us reference the Runtime (Game)Objects in the Unity Editor.

This is very useful in multi-scene projects, where you want to reference the objects between scenes without hassle.
Also, it can be used to reference the runtime objects in other scriptable objects, like variables, events, scenarions, etc.

## Features

- **Runtime Anchors** - A set of ScriptableObjects that can be used to reference the runtime objects in the Unity Editor.
    - Simply extendable the [`RuntimeAnchorBase<T>`](Runtime/Base/RuntimeAnchorBase.cs) class to create your own anchor types, see examples
      in the [`GameObjectAnchor`](Runtime/GameObjectAnchor.cs) folder.
- **Runtime Anchor References** - A way to reference (Game)Objects using inlined reference or by using the (runtime) anchor reference.
    - You can directly set the value in the Inspector or reference a runtime anchor.
    - This makes flexible go to choice how to use the runtime anchors in your scripts.
    - You can use the [`AnchorReferenceBase<T>`](Runtime/Base/Reference/AnchorReferenceBase.cs) class to create your own anchor references.
- **Auto Anchor Provider** - A component that will automatically set the (runtime) anchor reference to the GameObject it is attached to as soon as the
  GameObject is instantiated.
    - This is useful for automatically setting the anchor reference to the GameObject without having to manually initialize it in the code.
    - You can extend the [`AutoAnchorProviderBase`](Runtime/Base/AutoAnchorProviderBase.cs) component to automatically set the anchor reference.

## Installation

Install the package using npm scoped registry in `Project Settings > Package Manager > Scoped Registries`

```json
{
    "name": "NPM - xprees",
    "url": "https://registry.npmjs.org",
    "scopes": [
        "cz.xprees",
        "com.dbrizov.naughtyattributes"
    ]
}

```

Then simply install the package using the Unity Package Manager using the _NPM - xprees_ scope or by the package name `cz.xprees.runtime-anchors`.

