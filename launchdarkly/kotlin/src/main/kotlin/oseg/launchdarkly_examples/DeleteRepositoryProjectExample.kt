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
class DeleteRepositoryProjectExample
{
    fun deleteRepositoryProject()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            InsightsRepositoriesBetaApi().deleteRepositoryProject(
                repositoryKey = "repositoryKey_string",
                projectKey = "projectKey_string",
            )
        } catch (e: ClientException) {
            println("4xx response calling InsightsRepositoriesBetaApi#deleteRepositoryProject")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsRepositoriesBetaApi#deleteRepositoryProject")
            e.printStackTrace()
        }
    }
}
