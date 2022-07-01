---
marp: true
title: An Introduction to Akka .NET
theme: uncover
paginate: false
footer: "An Introduction to Akka .NET | :earth_americas: [SeanKilleen.com](https://SeanKilleen.com) | :bird: [@sjkilleen](https://twitter.com/sjkilleen)"
class: invert 
---

<!-- _footer: "" -->
![bg](./assets/images/mountains/kai-oberhauser-177237.jpg)

# AKKA.NET

# AN INTRODUCTION

<https://akkaintro.seankilleen.com>

---

# What We'll Cover

- Why this Matters
- Reactive Manifesto
- History / overview
- Concepts &amp; Benefits
- Demos

---
<!-- _footer: "" -->
<style scoped>
  ul {
    padding: 0;
    list-style: none;
  }
</style>

![bg left 60%](./assets/images/thanks/roger.jpg)

#### <!--fit--> Akka-knowledgements

## <!--fit-->Roger Johansson

- :bird: [@rogeralsing](http://twitter.com/rogeralsing)
- :envelope: [roger@nethouse.se](mailto:roger@nethouse.se)
- :earth_americas: [rogeralsing.com](https://rogeralsing.com)

---

![bg contain](./assets/images/rogerTweet.png)

---
<!-- _footer: "" -->
<style scoped>
  ul {
    padding: 0;
    list-style: none;
  }
</style>

![bg left 60%](./assets/images/thanks/Petabridge.png)

#### <!--fit--> Akka-knowledgements

## <!--fit-->Petabridge

- :bird: [@petabridge](http://twitter.com/petabridge)
- :bird: [@aaronontheweb](http://twitter.com/aaronontheweb)
- :earth_americas: [Petabridge.com](https://rPetabridge.com)

---

<!-- _footer: "" -->

![bg contain](./assets/images/dotNetFoundation.png)

---
<style scoped>
  ul {
    padding: 0;
    list-style: none;
  }
</style>
<!-- _footer: "" -->
![bg left 60%](./assets/images/thanks/me.png)

# <!--fit--> Hi! :wave: I'm Sean.

- :bird: [sjkilleen](https://twitter.com/sjkilleen)
- :earth_americas: [SeanKilleen.com](https://seankilleen.com)
- :briefcase: [Excella](https://excella.com)

---

![bg](./assets/images/mountains/daniel-leone-185834.jpg)

# Why This Matters

<!-- Previously: Old school request/response. 

Not good enough now -->

---

## Reactive Manifesto

<http://www.reactivemanifesto.org>

We need to evolve with our users' expectations.

---

## Reactive Systems Are:

- Responsive
- Resilient
- Elastic
- Message-Driven

---

## As a Result, They Are:

- Flexible
- Loosely-coupled
- Scalable
- Easier to Change
- Fault tolerant
- Fast

---

![bg](./assets/images/mountains/deniz-altindas-38121.jpg)

# Overview

---

#### Overview

## Actors: Not New

<!-- Carl Hewitt -- 1973 white paper -->

---

#### Overview

## Where are the actors?

<!--                 
Erlang 
Scala (Box)
LinkedIn (Java Akka)
Orleans (Xbox – Halo)
WhatsApp
Telecom etc.							
Finance | Data crunching | Event Streams
Neural networks
-->

---

#### Overview

## Akka and Akka.NET

<!-- Port of Java Akka -->

---

![bg](./assets/images/mountains/m-wong-40443.jpg)

# Concepts

---

#### Concepts

## Everything is an Actor

<!--
OOP Everything is an object; AM everything is an actor

Container for State, Behavior, Mailbox, Children, Supervision
-->

---

#### Concepts

## Encapsulation

<!-- 
ActorRef encapsulates Behavior / responsibility

Functions as one unit
-->

---

#### Concepts

## Immutable Messages

---

#### Concepts

## Actors by Reference

---

#### Concepts

## Props

---

## Every Actor Has:

- Address
- Context
- Supervision
- Mailbox
- Lifecycle

---

#### Addressing

## Protocol

<!-- TODO: Highlight -->
#### <!--fit--> akka.tcp://MySystem@localhost:8080/user/HelloWorldActor

---

#### Addressing

## System

<!-- TODO: Highlight -->
#### <!--fit--> akka.tcp://MySystem@localhost:8080/user/HelloWorldActor

---

#### Addressing

## Address

<!-- TODO: Highlight -->
#### <!--fit--> akka.tcp://MySystem@localhost:8080/user/HelloWorldActor

---

#### Addressing

## Path

<!-- TODO: Highlight -->
#### <!--fit--> akka.tcp://MySystem@localhost:8080/user/HelloWorldActor

---

<!-- TODO: Invert colors, get text to show up -->
![bg contain](./assets/images/Lifecycle.png)

---

![bg](./assets/images/mountains/patrick-hendry-198732.jpg)

# Context

<!-- 
Context.ActorOf is used to create children

Pretty subtle in that it's not always available

However, should know that every actor has one
-->

---
<!-- _footer: "" -->
![bg](./assets/images/ConceptAnimation.gif)

<!-- 
Event-driven thread; no polling

Behavior, State, Supervision

One Message at a time from Mailbox

Transport agnostic
-->

---

<!-- _footer: "" -->
#### Faults

## Classic .NET System

<!-- TODO: Image text -->
![](./assets/images/ClassicHierarchy_small.png)

<!--
Think of a classic OOP System

Exceptions may or may not bubble up

Unclear who is responsible for handling errors
-->

---

#### Faults

## Error Kernel

<!-- TODO: Image clarity -->
![](./assets/images/ErrorKernel_small.png)

<!--
System and User actors

Parent is responsible for children

Thinking about it up front at dev time
-->

---
<!-- _footer: "" -->

#### Faults

## Strategies

![](./assets/images/Strategies_Small2.png)

<!--
One for one vs. All for One

Easy custom supervisory structures 
-->

---

![bg](./assets/images/mountains/michal-janek-217220.jpg)

# Benefits

---

#### Benefits

# Async by Default

<!--
Who here writes great async code always? Your async code is probably terrible

Async without the cruft

Easier to reason about
-->

---

#### Benefits

# Recoverability

<!--
Child actors vs character actors

Scale out work across many actors

Push dangerous work into child actors
-->

---

#### Benefits

# Cheap!

<!--
No CPU unless a message is actually processing

~2.5 million actors per GB

50 million messages / sec on single machine
-->

---

#### Benefits

# Location Transparency

<!--
Think Cell phone grid 

You don't need to care where the actor lives

Can be changed via configuration without code updates

Same / different process, same / different machine
-->

---

#### Benefits

# Easy State Machines

<!--
Become / Unbecome

Can change how it will process next message

-->

---

#### Benefits

# Configurability

<!--
HOCON: Human-Optimized Config Object Notation

Fallback and layered configs

-->

---

#### Scaling

## Single Core

<!-- TODO: Fix image size -->
![](./assets/images/core/01.png)

<!--Single Core at first -->

---

#### Scaling

## Multi-threading

<!-- TODO: Fix image size -->
![](./assets/images/core/Multi.png)

<!-- 
Maybe then multi-core

Maybe then you'd adapt to use TPL or async / await

What happens when it's not enough?
-->
---

#### Scaling

## Scale Out
<!-- TODO: Fix image size -->

![](./assets/images/core/ScaleOut.png)

<!--
This is a key concept.

It's just code you write now

Adding more cores and more machines is the same

Reduce cost of change
-->

---

## Scaling Up &amp; Out:

# The :clap: Same :clap: Thing

---

![bg](./assets/images/mountains/yosh-ginsu-146166.jpg)

# Demos!

---

## :notes: We've Only Just Begun :notes:

- Persistence
- Clustering
- Streaming

<!--
Persistence: Journal of events using a base class (and snapshots!)

Clustering: Add / remove notes without adjusting. Peer to peer, gossip/consensus, trivial scale-out

Also poison pills: ordinary message that stops an actor

Also dead letters: When an actor terminates, sends messages here for recovery

Also service bus interoperability

Also .NET Core
-->

---

## Want More?

- [GetAkka.net](http://GetAkka.net)
- [Petabridge.com](http://Petabridge.com) and [Nethouse.se](http://nethouse.se)
- [GitHub: AkkaDotNet](http://github.com/Akkadotnet)

<!-- OSS is awesome -- get involved!-->

---

<style scoped>
  ul {
    padding: 0;
    list-style: none;
  }
</style>
<!-- _footer: "" -->
![bg left 60%](./assets/images/thanks/me.png)

# <!--fit--> Thanks!

- :bird: [sjkilleen](https://twitter.com/sjkilleen)
- :earth_americas: [SeanKilleen.com](https://seankilleen.com)
- :briefcase: [Excella](https://excella.com)
