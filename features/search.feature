Feature: Searching for Products
  In order to find a particular product
  The a customer
  Needs to search the catalog

Scenario: Search for one product
  Given the following "Blowout Specials":
    |name|
    |Cascade Fur-lined Hiking Boots|
    |Trailhead Locking Carabiner|
    |Climbing Rope with Single Caribiner|
  When I search for "Boots"
  Then I should see "Cascade Fur-lined Hiking Boots" listed
