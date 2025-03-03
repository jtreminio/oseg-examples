=begin
#NamSor API v2

#NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 

The version of the OpenAPI document: 2.0.29
Contact: contact@namsor.com
Generated by: https://openapi-generator.tech
Generator version: 7.11.0

=end

require 'cgi'

module NamsorClient
  class SocialApi
    attr_accessor :api_client

    def initialize(api_client = ApiClient.default)
      @api_client = api_client
    end
    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, given a personal name and formatted / unformatted phone number.
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param [Hash] opts the optional parameters
    # @return [FirstLastNamePhoneCodedOut]
    def phone_code(first_name, last_name, phone_number, opts = {})
      data, _status_code, _headers = phone_code_with_http_info(first_name, last_name, phone_number, opts)
      data
    end

    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, given a personal name and formatted / unformatted phone number.
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(FirstLastNamePhoneCodedOut, Integer, Hash)>] FirstLastNamePhoneCodedOut data, response status code and response headers
    def phone_code_with_http_info(first_name, last_name, phone_number, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SocialApi.phone_code ...'
      end
      # verify the required parameter 'first_name' is set
      if @api_client.config.client_side_validation && first_name.nil?
        fail ArgumentError, "Missing the required parameter 'first_name' when calling SocialApi.phone_code"
      end
      # verify the required parameter 'last_name' is set
      if @api_client.config.client_side_validation && last_name.nil?
        fail ArgumentError, "Missing the required parameter 'last_name' when calling SocialApi.phone_code"
      end
      # verify the required parameter 'phone_number' is set
      if @api_client.config.client_side_validation && phone_number.nil?
        fail ArgumentError, "Missing the required parameter 'phone_number' when calling SocialApi.phone_code"
      end
      # resource path
      local_var_path = '/api2/json/phoneCode/{firstName}/{lastName}/{phoneNumber}'.sub('{' + 'firstName' + '}', CGI.escape(first_name.to_s)).sub('{' + 'lastName' + '}', CGI.escape(last_name.to_s)).sub('{' + 'phoneNumber' + '}', CGI.escape(phone_number.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'FirstLastNamePhoneCodedOut'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['api_key']

      new_options = opts.merge(
        :operation => :"SocialApi.phone_code",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SocialApi#phone_code\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, detecting automatically the local context given a name and formatted / unformatted phone number.
    # @param [Hash] opts the optional parameters
    # @option opts [BatchFirstLastNamePhoneNumberIn] :batch_first_last_name_phone_number_in A list of personal names
    # @return [BatchFirstLastNamePhoneCodedOut]
    def phone_code_batch(opts = {})
      data, _status_code, _headers = phone_code_batch_with_http_info(opts)
      data
    end

    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, detecting automatically the local context given a name and formatted / unformatted phone number.
    # @param [Hash] opts the optional parameters
    # @option opts [BatchFirstLastNamePhoneNumberIn] :batch_first_last_name_phone_number_in A list of personal names
    # @return [Array<(BatchFirstLastNamePhoneCodedOut, Integer, Hash)>] BatchFirstLastNamePhoneCodedOut data, response status code and response headers
    def phone_code_batch_with_http_info(opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SocialApi.phone_code_batch ...'
      end
      # resource path
      local_var_path = '/api2/json/phoneCodeBatch'

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(opts[:'batch_first_last_name_phone_number_in'])

      # return_type
      return_type = opts[:debug_return_type] || 'BatchFirstLastNamePhoneCodedOut'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['api_key']

      new_options = opts.merge(
        :operation => :"SocialApi.phone_code_batch",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SocialApi#phone_code_batch\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # [USES 11 UNITS PER NAME] Infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param country_iso2 [String] 
    # @param [Hash] opts the optional parameters
    # @return [FirstLastNamePhoneCodedOut]
    def phone_code_geo(first_name, last_name, phone_number, country_iso2, opts = {})
      data, _status_code, _headers = phone_code_geo_with_http_info(first_name, last_name, phone_number, country_iso2, opts)
      data
    end

    # [USES 11 UNITS PER NAME] Infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param country_iso2 [String] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(FirstLastNamePhoneCodedOut, Integer, Hash)>] FirstLastNamePhoneCodedOut data, response status code and response headers
    def phone_code_geo_with_http_info(first_name, last_name, phone_number, country_iso2, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SocialApi.phone_code_geo ...'
      end
      # verify the required parameter 'first_name' is set
      if @api_client.config.client_side_validation && first_name.nil?
        fail ArgumentError, "Missing the required parameter 'first_name' when calling SocialApi.phone_code_geo"
      end
      # verify the required parameter 'last_name' is set
      if @api_client.config.client_side_validation && last_name.nil?
        fail ArgumentError, "Missing the required parameter 'last_name' when calling SocialApi.phone_code_geo"
      end
      # verify the required parameter 'phone_number' is set
      if @api_client.config.client_side_validation && phone_number.nil?
        fail ArgumentError, "Missing the required parameter 'phone_number' when calling SocialApi.phone_code_geo"
      end
      # verify the required parameter 'country_iso2' is set
      if @api_client.config.client_side_validation && country_iso2.nil?
        fail ArgumentError, "Missing the required parameter 'country_iso2' when calling SocialApi.phone_code_geo"
      end
      # resource path
      local_var_path = '/api2/json/phoneCodeGeo/{firstName}/{lastName}/{phoneNumber}/{countryIso2}'.sub('{' + 'firstName' + '}', CGI.escape(first_name.to_s)).sub('{' + 'lastName' + '}', CGI.escape(last_name.to_s)).sub('{' + 'phoneNumber' + '}', CGI.escape(phone_number.to_s)).sub('{' + 'countryIso2' + '}', CGI.escape(country_iso2.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'FirstLastNamePhoneCodedOut'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['api_key']

      new_options = opts.merge(
        :operation => :"SocialApi.phone_code_geo",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SocialApi#phone_code_geo\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, with a local context (ISO2 country of residence).
    # @param [Hash] opts the optional parameters
    # @option opts [BatchFirstLastNamePhoneNumberGeoIn] :batch_first_last_name_phone_number_geo_in A list of personal names
    # @return [BatchFirstLastNamePhoneCodedOut]
    def phone_code_geo_batch(opts = {})
      data, _status_code, _headers = phone_code_geo_batch_with_http_info(opts)
      data
    end

    # [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, with a local context (ISO2 country of residence).
    # @param [Hash] opts the optional parameters
    # @option opts [BatchFirstLastNamePhoneNumberGeoIn] :batch_first_last_name_phone_number_geo_in A list of personal names
    # @return [Array<(BatchFirstLastNamePhoneCodedOut, Integer, Hash)>] BatchFirstLastNamePhoneCodedOut data, response status code and response headers
    def phone_code_geo_batch_with_http_info(opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SocialApi.phone_code_geo_batch ...'
      end
      # resource path
      local_var_path = '/api2/json/phoneCodeGeoBatch'

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(opts[:'batch_first_last_name_phone_number_geo_in'])

      # return_type
      return_type = opts[:debug_return_type] || 'BatchFirstLastNamePhoneCodedOut'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['api_key']

      new_options = opts.merge(
        :operation => :"SocialApi.phone_code_geo_batch",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SocialApi#phone_code_geo_batch\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # [CREDITS 1 UNIT] Feedback loop to better infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param phone_number_e164 [String] 
    # @param country_iso2 [String] 
    # @param [Hash] opts the optional parameters
    # @return [FirstLastNamePhoneCodedOut]
    def phone_code_geo_feedback_loop(first_name, last_name, phone_number, phone_number_e164, country_iso2, opts = {})
      data, _status_code, _headers = phone_code_geo_feedback_loop_with_http_info(first_name, last_name, phone_number, phone_number_e164, country_iso2, opts)
      data
    end

    # [CREDITS 1 UNIT] Feedback loop to better infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).
    # @param first_name [String] 
    # @param last_name [String] 
    # @param phone_number [String] 
    # @param phone_number_e164 [String] 
    # @param country_iso2 [String] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(FirstLastNamePhoneCodedOut, Integer, Hash)>] FirstLastNamePhoneCodedOut data, response status code and response headers
    def phone_code_geo_feedback_loop_with_http_info(first_name, last_name, phone_number, phone_number_e164, country_iso2, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SocialApi.phone_code_geo_feedback_loop ...'
      end
      # verify the required parameter 'first_name' is set
      if @api_client.config.client_side_validation && first_name.nil?
        fail ArgumentError, "Missing the required parameter 'first_name' when calling SocialApi.phone_code_geo_feedback_loop"
      end
      # verify the required parameter 'last_name' is set
      if @api_client.config.client_side_validation && last_name.nil?
        fail ArgumentError, "Missing the required parameter 'last_name' when calling SocialApi.phone_code_geo_feedback_loop"
      end
      # verify the required parameter 'phone_number' is set
      if @api_client.config.client_side_validation && phone_number.nil?
        fail ArgumentError, "Missing the required parameter 'phone_number' when calling SocialApi.phone_code_geo_feedback_loop"
      end
      # verify the required parameter 'phone_number_e164' is set
      if @api_client.config.client_side_validation && phone_number_e164.nil?
        fail ArgumentError, "Missing the required parameter 'phone_number_e164' when calling SocialApi.phone_code_geo_feedback_loop"
      end
      # verify the required parameter 'country_iso2' is set
      if @api_client.config.client_side_validation && country_iso2.nil?
        fail ArgumentError, "Missing the required parameter 'country_iso2' when calling SocialApi.phone_code_geo_feedback_loop"
      end
      # resource path
      local_var_path = '/api2/json/phoneCodeGeoFeedbackLoop/{firstName}/{lastName}/{phoneNumber}/{phoneNumberE164}/{countryIso2}'.sub('{' + 'firstName' + '}', CGI.escape(first_name.to_s)).sub('{' + 'lastName' + '}', CGI.escape(last_name.to_s)).sub('{' + 'phoneNumber' + '}', CGI.escape(phone_number.to_s)).sub('{' + 'phoneNumberE164' + '}', CGI.escape(phone_number_e164.to_s)).sub('{' + 'countryIso2' + '}', CGI.escape(country_iso2.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'FirstLastNamePhoneCodedOut'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['api_key']

      new_options = opts.merge(
        :operation => :"SocialApi.phone_code_geo_feedback_loop",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SocialApi#phone_code_geo_feedback_loop\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end
  end
end
