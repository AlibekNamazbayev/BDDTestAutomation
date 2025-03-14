Feature: Navigation to Services Section

  Scenario Outline: Validate Navigation to Services Section for <ServiceCategory>
    Given I navigate to the EPAM homepage
    When I click on the "Services" link in the main navigation menu
    And I select the "<ServiceCategory>" category from the dropdown
    Then the page title should be correct
    And the "Our Related Expertise" section should be displayed

  Examples:
    | ServiceCategory  |
    | Generative AI    |
    | Responsible AI   |
