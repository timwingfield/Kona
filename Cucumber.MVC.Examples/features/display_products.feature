Feature: Display Products
In order to browse the catalog
As a customer
I want to see products

Scenario: Featured Products
    Given the featured product "Adventure Works 20x30 Binoculars"
    When I visit the homepage
    Then I should see "Adventure Works 20x30 Binoculars" listed under "Featured"

Scenario: Blowout Specials
    Given the following "Blowout Specials":
       |name|
       |Cascade Fur-lined Hiking Boots|
       |Trailhead Locking Carabiner|
       |Climbing Rope with Single Caribiner|
    When I visit the homepage
    Then I should see "Cascade Fur-lined Hiking Boots" listed under "Blowout Specials"
    And I should see "Trailhead Locking Carabiner" listed under "Blowout Specials"
    And I should see "Climbing Rope with Single Caribiner" listed under "Blowout Specials"

Scenario Outline: Blowout Specials
    Given <product> "Blowout Specials" product
    When I visit the homepage
    Then I should see <product> listed under "Blowout Specials"

    Examples:
      | product                                     |
      |  "Cascade Fur-lined Hiking Boots"           |
      |  "Trailhead Locking Carabiner"              |
      |  "Climbing Rope with Single Caribiner"      |  

Scenario Outline: Categories work as expected
    Given <product> <category> product
    When I visit the <category>
    Then I should see <product> listed

    Examples:
      | product                                     |  category       |
      |  "Adventure Works 20x30 Binoculars"         |  "Camping Gear" |
      |  "Sierra Leather Hiking Boots"              |  "Camping Gear" |
      |  "Sprint 500 Bike"                          |  "Biking Gear"  |