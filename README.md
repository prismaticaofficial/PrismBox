# PRISMBOX

PrismBox is a mod designed to make modding easier for me. Perhaps it can help you, too.
<br><br>

## WHAT IS THIS?

As defined above, PrismBox is a personal-use library I am working on that I've decided to make public. <br>
A lot of this is experimental / helper functions to make modding for me easier. However, I figured someone else might want to use it as well. <br> <br>

Do note we use the GPL3.0 License, meaning any project you create with PrismBox must be open source! <br> <br>

For a detailed documentation and feature showcase, please visit the provided wiki in this repository (as of 3/10/2024, still working on it!) <br>

## FEATURES PROVIDED

### Entity Component Architecture
Most* entities now follow a component-based content format, meaning every behavior is defined by a component.
A guide for this architecture is readable in the Wiki.<br>

*Projectiles and custom ModTypes pending impl. Please be patient!

### Entity Extensions
Various entity-centered extensions for both the component impl and for various shorthand checks across all entity types.

### Status Effects (Component-Based Buff Impl) [EXPERIMENTAL]
Components now handle buffs and utilize custom drawing and update techniques. 
ModBuff and the original buff system are marked obsolete.

### ModInvasion, an Impl of Custom Invasion Types [EXPERIMENTAL]
``ModInvasion`` is a concept a lot of developers seek to implement but never made an official release of. PrismBox attempts its own, along with extra functions.

## 

## CONTRIBUTE

Have something you'd like to add to PrismBox you think everyone else should use?<br>
Make a PR!<br>
Make a DM! (@prismatica_official on Discord)<br>

## CREDIT

Certain additions and architectural choices were inspired by the following developers!<br>

- Tomat (Steviegt6) => Mod disablers in ``CrossmodHelper``
- absoluteAquarian => ModType handling
- LolXD87 => Primitive Drawing (prims) impl suggestion
- Naka => Entity-Component Architecture proposal
- Mirsario => Entity-Component Architecture proposal [link]