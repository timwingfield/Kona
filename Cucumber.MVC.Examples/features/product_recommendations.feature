Feature: Recommending products
  In order to increase conversions
  The a customer
  Needs to be recommended to other products

Scenario: Recommendations should include other similar purchased products
  Given customer order for "Trailhead Locking Carabiner" and "Climbing Rope with Single Caribiner"
  And customer order for "Trailhead Locking Carabiner" and "North Star Compass"
  When I visit the "Trailhead Locking Carabiner" details page
  Then I should see "Climbing Rope with Single Caribiner" listed under "recommendations"
  Then I should see "North Star Compass" listed under "recommendations"

Scenario: Recommendations should not include unrelated products
  Given customer order for "Trailhead Locking Carabiner" and "Climbing Rope with Single Caribiner"
  And customer order for "Adventure Works Basic 4 Tent"
  When I visit the "Trailhead Locking Carabiner" details page
  Then I should see "Climbing Rope with Single Caribiner" listed under "recommendations"
  But I should not see "Adventure Works Basic 4 Tent" listed under "recommendations"

Scenario: Recommendations 
  Given customer order for "Trailhead Locking Carabiner" and "Climbing Rope with Single Caribiner"
  And customer order for "Trailhead Locking Carabiner" and "North Star Compass"
  When I visit the "Trailhead Locking Carabiner" details page
  Then I should see "Climbing Rope with Single Caribiner" listed under "recommendations"
  Then I should see "North Star Compass" listed under "recommendations"

Scenario: Recommendations should not include itself
  Given customer order for "Trailhead Locking Carabiner" and "Climbing Rope with Single Caribiner"
  And customer order for "Trailhead Locking Carabiner" and "North Star Compass"
  When I visit the "Trailhead Locking Carabiner" details page
  Then I should not see "Trailhead Locking Carabiner" listed under "recommendations"  