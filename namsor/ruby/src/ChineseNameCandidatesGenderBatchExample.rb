require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGenderIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1.first_name = "LiYing"
personal_names_1.last_name = "Zhao"
personal_names_1.gender = "female"

personal_names = [
    personal_names_1,
]

batch_first_last_name_gender_in = NamsorClient::BatchFirstLastNameGenderIn.new
batch_first_last_name_gender_in.personal_names = personal_names

begin
    response = NamsorClient::ChineseApi.new.chinese_name_candidates_gender_batch(
        {
            batch_first_last_name_gender_in: batch_first_last_name_gender_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#chinese_name_candidates_gender_batch: #{e}"
end
