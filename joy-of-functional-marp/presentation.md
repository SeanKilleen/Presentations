---
marp: true
title: The Joy of Functional Testing with SpecFlow
theme: uncover
paginate: true
_paginate: false
---

## The Joy

## of Functional Testing

An Introduction with SpecFlow

[https://JoyOfFunctionalTesting.seankilleen.com/](https://JoyOfFunctionalTesting.seankilleen.com/)

---

![bg](./images/CapTech_Logo_Tagline-White.png)

---

![bg](./images/dotNetFoundation.png)

---

<!-- <Split>

![](images/me.png)

<h3 class="less-bottom-margin"> Hi! I'm Sean.</h3>
<ul class="fa-ul">
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faTwitter} listItem /> @sjkilleen</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faGithub} listItem />SeanKilleen</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faGlobe} listItem />SeanKilleen.com</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faBriefcase} listItem />CapTechConsulting.com</li>
</ul>

</Split>

--- -->

## Let's Do this

* Why this matters
* Specification by example
* Functional / Acceptance Testing
* Gherkin syntax
* Benefits
* SpecFlow demos

---

# Why this matters

---

![bg](./images/move-fast-break.png)

---

#### Why this matters

# Confusion

---

#### Why this matters

# Trust

---

#### Why this matters

# Feature Fighting

---

![bg](./images/roxbury.jpg)

---

![bg](./images/safety-harness.jpg)

---

![bg](./images/specbyexample-cover.jpg)

---

## Functional &amp;

## Acceptance Tests

---

![bg](./images/quadrants-before.png)

---

![bg](./images/quadrants-selection.png)

---

![bg](./images/unit-vs-int-1.gif)

---

![bg](./images/unit-vs-int-2.gif)

---

![bg](./images/unit-vs-int-3.gif)

---

![bg](./images/unit-vs-int-4.jpg)

---

# Gherkin Syntax

---

#### Gherkin Syntax

* Given
* When
* Then

---

#### Gherkin Syntax

Old and busted:

```
A system shall allow login access 
```

---

#### Gherkin Syntax

New hotness:

```
Given I am on the home page
  And I have clicked the login button
When I enter a valid username
  And I enter a valid password
  And I login
Then I should be redirected to my profile page
```

---

![bg](./images/gherkin-shoppingcart.png)

---

# Benefits

---

![bg](./images/examples-tests-requirements.png)

---

![bg](./images/atdd.png)

---

#### Benefits

# Consensus

---

#### Benefits

# Shift to the Left

---

#### Benefits

# Sign-Off

---

#### Benefits

# Missed Requirements

---

# SpecFlow

---

![bg](./images/glue-diagram.png)

---

![bg](./images/ship-launch-fail.gif)

<!-- <Split>

![](images/me.png)

<h3 class="less-bottom-margin">Thanks!</h3>
<ul class="fa-ul">
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faTwitter} listItem /> @sjkilleen</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faGithub} listItem />SeanKilleen</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faGlobe} listItem />SeanKilleen.com</li>
    <li class="fa-li"><FontAwesomeIcon size="xs" icon ={faBriefcase} listItem />CapTechConsulting.com</li>
</ul>

</Split> -->
