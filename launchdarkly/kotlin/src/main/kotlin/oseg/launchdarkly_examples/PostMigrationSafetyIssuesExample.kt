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
class PostMigrationSafetyIssuesExample
{
    fun postMigrationSafetyIssues()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val flagSempatch = FlagSempatch(
            instructions = listOf (),
            comment = null,
        )

        try
        {
            val response = FeatureFlagsApi().postMigrationSafetyIssues(
                projectKey = null,
                flagKey = null,
                environmentKey = null,
                flagSempatch = flagSempatch,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FeatureFlagsApi#postMigrationSafetyIssues")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FeatureFlagsApi#postMigrationSafetyIssues")
            e.printStackTrace()
        }
    }
}
