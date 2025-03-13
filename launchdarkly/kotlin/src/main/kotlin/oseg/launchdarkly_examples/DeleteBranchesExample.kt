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
class DeleteBranchesExample
{
    fun deleteBranches()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            CodeReferencesApi().deleteBranches(
                repo = null,
                requestBody = listOf (
                    "branch-to-be-deleted",
                    "another-branch-to-be-deleted",
                ),
            )
        } catch (e: ClientException) {
            println("4xx response calling CodeReferencesApi#deleteBranches")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CodeReferencesApi#deleteBranches")
            e.printStackTrace()
        }
    }
}
