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
class AssociateRepositoriesAndProjectsExample
{
    fun associateRepositoriesAndProjects()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val mappings1 = InsightsRepositoryProject(
            repositoryKey = "launchdarkly/LaunchDarkly-Docs",
            projectKey = "default",
        )

        val mappings = arrayListOf<InsightsRepositoryProject>(
            mappings1,
        )

        val insightsRepositoryProjectMappings = InsightsRepositoryProjectMappings(
            mappings = mappings,
        )

        try
        {
            val response = InsightsRepositoriesBetaApi().associateRepositoriesAndProjects(
                insightsRepositoryProjectMappings = insightsRepositoryProjectMappings,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InsightsRepositoriesBetaApi#associateRepositoriesAndProjects")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsRepositoriesBetaApi#associateRepositoriesAndProjects")
            e.printStackTrace()
        }
    }
}
