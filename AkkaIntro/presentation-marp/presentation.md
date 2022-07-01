---
marp: true
title: An Introduction to Akka .NET
theme: uncover
paginate: false
footer: "An Introduction to Akka .NET | :earth_americas: [SeanKilleen.com](https://SeanKilleen.com) | :bird: [@sjkilleen](https://twitter.com/sjkilleen)"
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
