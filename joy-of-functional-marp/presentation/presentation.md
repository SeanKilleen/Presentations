---
marp: true
title: The Joy of Functional Testing with SpecFlow
theme: uncover
paginate: false
footer: "Joy of Functional Testing w/SpecFlow | :earth_americas: [SeanKilleen.com](https://SeanKilleen.com) | :bird: [@sjkilleen](https://twitter.com/sjkilleen)"
---

# The Joy

# of Functional Testing

An Introduction with SpecFlow

[JoyOfFunctionalTesting.seankilleen.com](https://JoyOfFunctionalTesting.seankilleen.com/)

---

![bg contain](./assets/images/excella2.jpg)

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
![bg left 60%](./assets/images/me.png)

# <!--fit--> Hi! :wave: I'm Sean.

- :bird: [sjkileen](https://twitter.com/sjkilleen)
- :earth_americas: [SeanKilleen.com](https://seankilleen.com)
- :briefcase: [Excella](https://excella.com)

---

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

<!-- _footer: "" -->
![bg contain](./assets/images/move-fast-break.png)

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

<!-- _footer: "" -->
![bg contain](./assets/images/roxbury.jpg)

---

<!-- _footer: "" -->
![bg cover](./assets/images/safety-harness.jpg)

---

<!-- _footer: "" -->
![bg contain](./assets/images/specbyexample-cover.jpg)

---

## Functional &amp;

## Acceptance Tests

---
<!-- _footer: "" -->

![bg contain](./assets/images/quadrants-before.png)

---
<!-- _footer: "" -->

![bg contain](./assets/images/quadrants-selection.png)

---
<!-- _footer: "" -->

![bg contain](./assets/images/unit-vs-int-1.gif)

---
<!-- _footer: "" -->

![bg contain](./assets/images/unit-vs-int-2.gif)

---

<!-- _footer: "" -->
![bg contain](./assets/images/unit-vs-int-3.gif)

---
<!-- _footer: "" -->

![bg contain](./assets/images/unit-vs-int-4.jpg)

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
<!-- _footer: "" -->

![bg contain](./assets/images/gherkin-shoppingcart.png)

---

# Benefits

---

![bg contain](./assets/images/examples-tests-requirements.png)

---

![bg contain](./assets/images/atdd.png)

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

![bg contain](./assets/images/glue-diagram.png)

---
<!-- _footer: "" -->

![bg](./assets/images/ship-launch-fail.gif)

---
<style scoped>
  ul {
    padding: 0;
    list-style: none;
  }
</style>
<!-- _footer: "" -->

![bg left 60%](./assets/images/me.png)

# Thanks!

- :bird: [sjkileen](https://twitter.com/sjkilleen)
- :earth_americas: [SeanKilleen.com](https://seankilleen.com)
- :briefcase: [Excella](https://excella.com)
