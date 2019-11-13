Feature: VendingMachineProduct
	As a hungry customer
	I want to receive a product 
	So that I can experience a yummy treat

Scenario: Receive a Product
	Given I am at the vending machine
	When I insert a quarter
		And I insert a quarter
		And I purchase a product
	Then I should receive the product
