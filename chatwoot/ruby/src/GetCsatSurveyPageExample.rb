require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

begin
    ChatwootClient::CSATSurveyPageApi.new.get_csat_survey_page(
        0, # conversation_uuid
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CSATSurveyPageApi#get_csat_survey_page: #{e}"
end
