Feature: Display Products
In order to browse the catalog
As a customer
I want to see products

  Scenario: Featured Products
    Given the featured product "Adventure Works 20x30 Binoculars"
    When I visit the homepage
    Then I should see "Adventure Works 20x30 Binoculars" listed under "Featured"

Scenario: Blowout Specials
    Given the following Blowout Specials:
       |name|
       |Cascade Fur-lined Hiking Boots|
       |Trailhead Locking Carabiner|
       |Climbing Rope with Single Caribiner|
    When I visit the homepage
    Then I should see "Cascade Fur-lined Hiking Boots" listed under "Blowout Specials"
    And I should see "Trailhead Locking Carabiner" listed under "Blowout Specials"
    And I should see "Climbing Rope with Single Caribiner" listed under "Blowout Specials"
