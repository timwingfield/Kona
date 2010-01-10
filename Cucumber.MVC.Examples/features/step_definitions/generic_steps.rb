When /^I visit the homepage$/ do
  visit url + '/'
end

When /^I visit the "([^\"]*)"$/ do |category|
  visit url + '/'
  click_link category
end
