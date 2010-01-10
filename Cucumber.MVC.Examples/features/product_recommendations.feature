Feature: Recommending products
  In order to increase conversions
  The a customer
  Needs to be recommended to other products

Scenario: Recommendation list
  Given customer order for "Rainier Leather Hiking Boots" and "Adventure Works Basic 4 Tent"
  And customer order for "Sierra Leather Hiking Boots" and "Rainier Leather Hiking Boots"
  And customer order for "Adventure Works Basic 4 Tent"
  When I visit the "Rainier Leather Hiking Boots" details page
  Then I should see "Adventure Works Basic 4 Tent" listed under "recommendations"
  Then I should see "Sierra Leather Hiking Boots" listed under "recommendations"
  But I should not see "Rainier Leather Hiking Boots" listed under "recommendations"
