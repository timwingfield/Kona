Given /^the featured product "([^\"]*)"$/ do |product|
end

Given /^the following Blowout Specials:$/ do |products|
  products.hashes.map do |p|
      p[:name]
    end
end

When /^I visit the homepage$/ do
  visit url + '/'
end

Then /^I should see "([^\"]*)" listed under "([^\"]*)"$/ do |product, area|
  within get_div_id(area) do |products|
    products.should contain(product)
  end
end

def get_div_id(id)
  "#" + id.downcase.underscore
end