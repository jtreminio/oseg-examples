package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateFlagImportConfigurationExample
{
    fun createFlagImportConfiguration()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val flagImportConfigurationPost = FlagImportConfigurationPost(
            config = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "environmentId": "The ID of the environment in the external system",
                    "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
                    "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
                    "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
                    "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
                    "workspaceApiKey": "An API key with read permissions in the external feature management system",
                    "workspaceId": "The ID of the workspace in the external system"
                }
            """)!!,
            name = "Sample configuration",
            tags = listOf (
                "example-tag",
            ),
        )

        try
        {
            val response = FlagImportConfigurationsBetaApi().createFlagImportConfiguration(
                projectKey = null,
                integrationKey = null,
                flagImportConfigurationPost = flagImportConfigurationPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration")
            e.printStackTrace()
        }
    }
}
