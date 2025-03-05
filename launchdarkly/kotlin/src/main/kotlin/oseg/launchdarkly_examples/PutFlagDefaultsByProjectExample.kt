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
class PutFlagDefaultsByProjectExample
{
    fun putFlagDefaultsByProject()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val booleanDefaults = BooleanFlagDefaults(
            trueDisplayName = "True",
            falseDisplayName = "False",
            trueDescription = "serve true",
            falseDescription = "serve false",
            onVariation = 0,
            offVariation = 1,
        )

        val defaultClientSideAvailability = DefaultClientSideAvailability(
            usingMobileKey = true,
            usingEnvironmentId = true,
        )

        val upsertFlagDefaultsPayload = UpsertFlagDefaultsPayload(
            temporary = true,
            tags = listOf (
                "tag-1",
                "tag-2",
            ),
            booleanDefaults = booleanDefaults,
            defaultClientSideAvailability = defaultClientSideAvailability,
        )

        try
        {
            val response = ProjectsApi().putFlagDefaultsByProject(
                projectKey = null,
                upsertFlagDefaultsPayload = upsertFlagDefaultsPayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ProjectsApi#putFlagDefaultsByProject")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ProjectsApi#putFlagDefaultsByProject")
            e.printStackTrace()
        }
    }
}
