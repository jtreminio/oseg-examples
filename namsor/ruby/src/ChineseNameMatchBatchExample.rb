require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1_name1 = NamsorClient::FirstLastNameIn.new
personal_names_1_name1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1_name1.first_name = "Hong"
personal_names_1_name1.last_name = "Yu"

personal_names_1_name2 = NamsorClient::PersonalNameIn.new
personal_names_1_name2.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c43"
personal_names_1_name2.name = "喻红"

personal_names_1 = NamsorClient::MatchPersonalFirstLastNameIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c41"
personal_names_1.name1 = personal_names_1_name1
personal_names_1.name2 = personal_names_1_name2

personal_names = [
    personal_names_1,
]

batch_match_personal_first_last_name_in = NamsorClient::BatchMatchPersonalFirstLastNameIn.new
batch_match_personal_first_last_name_in.personal_names = personal_names

begin
    response = NamsorClient::ChineseApi.new.chinese_name_match_batch(
        {
            batch_match_personal_first_last_name_in: batch_match_personal_first_last_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#chinese_name_match_batch: #{e}"
end
