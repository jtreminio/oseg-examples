require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

references_1_hunks_1 = LaunchDarklyClient::HunkRep.new
references_1_hunks_1.starting_line_number = 45
references_1_hunks_1.lines = "var enableFeature = 'enable-feature';"
references_1_hunks_1.proj_key = "default"
references_1_hunks_1.flag_key = "enable-feature"
references_1_hunks_1.aliases = [
    "enableFeature",
    "EnableFeature",
]

references_1_hunks = [
    references_1_hunks_1,
]

references_1 = LaunchDarklyClient::ReferenceRep.new
references_1.path = "/main/index.js"
references_1.hint = "javascript"
references_1.hunks = references_1_hunks

references = [
    references_1,
]

put_branch = LaunchDarklyClient::PutBranch.new
put_branch.name = "main"
put_branch.head = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"
put_branch.sync_time = 1706701522000
put_branch.update_sequence_id = 25
put_branch.commit_time = 1706701522000
put_branch.references = references

begin
    LaunchDarklyClient::CodeReferencesApi.new.put_branch(
        nil, # repo
        nil, # branch
        put_branch,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferences#put_branch: #{e}"
end
