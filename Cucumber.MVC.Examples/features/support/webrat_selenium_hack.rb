module Webrat
  class SeleniumSession
    extend Forwardable

    # Add more methods of webrat/core/session when needed
    def_delegators :current_scope, :field_labeled, :table_at, :css_search

    def within(selector)
      scopes.push(Webrat::Scope.from_scope(self, current_scope, selector))
      ret = yield(current_scope)
      scopes.pop
      return ret
    end

    def current_scope
      scopes.last || page_scope
    end

    def page_scope
      Webrat::Scope.from_page(self, response, response_body)
    end

    def scopes
      @_scopes ||= []
    end

    def xml_content_type?
      false
    end

    def current_dom #:nodoc:
      current_scope.dom
    end

    def elements
      {}
    end
  end

  class Scope
    def selenium
      return @session.response
    end
  end

  class SeleniumResponse
    def is_text_present(text_finder)
      body.include? text_finder
    end
  end
end